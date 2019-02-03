using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class CategoriaController : Controller
    {
        private ApplicationDbContext _contexto;

        public CategoriaController(ApplicationDbContext contexto){
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Salvar(){
            return View();
        }

      [HttpPost]
        public async Task<IActionResult> Salvar(Categoria categoria){
            _contexto.Categorias.Add(categoria);
            //métodos assincronos otimizam as treads  
            await _contexto.SaveChangesAsync();
            return View();
        }                
    }
}