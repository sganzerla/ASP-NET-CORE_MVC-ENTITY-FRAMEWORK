using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace Mvc.Controllers
{
    public class CategoriaController : Controller
    {
        private ApplicationDbContext _contexto;

        public CategoriaController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categorias = _contexto.Categorias.ToList();
            return View(categorias);
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var categoria = _contexto.Categorias.First(c => c.Id == id);
            return View("Salvar", categoria);
        }
        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            var categoria = _contexto.Categorias.First(c => c.Id == id);
            _contexto.Categorias.Remove(categoria);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Categoria categoriaPersist)
        {
            if (categoriaPersist.Id == 0)
                _contexto.Categorias.Add(categoriaPersist);
            else
            {
                var categoria = _contexto.Categorias.First(c => c.Id == categoriaPersist.Id);
                categoria.Nome = categoriaPersist.Nome;
                categoria.PermiteEstoque = categoriaPersist.PermiteEstoque;
            }

            //métodos assincronos otimizam as treads  
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}