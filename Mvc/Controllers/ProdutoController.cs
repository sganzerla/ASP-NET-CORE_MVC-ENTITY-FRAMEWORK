using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        private ApplicationDbContext _contexto;

        public ProdutoController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var produtos = _contexto.Produtos.Include(p => p.Categoria).ToList();
          // com lazyloading habilitado  var produtos = _contexto.Produtos.ToList();
            return View(produtos);
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = _contexto.Produtos.First(c => c.Id == id);
            return View("Salvar", produto);
        }
        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            var produto = _contexto.Produtos.First(c => c.Id == id);
            _contexto.Produtos.Remove(produto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            ViewBag.Categorias = _contexto.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Produto produtoPersist)
        {
            if (produtoPersist.Id == 0)
                _contexto.Produtos.Add(produtoPersist);
            else
            {
                var produto = _contexto.Produtos.First(c => c.Id == produtoPersist.Id);
                produto.Nome = produtoPersist.Nome;
            }

            //métodos assincronos otimizam as treads  
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}