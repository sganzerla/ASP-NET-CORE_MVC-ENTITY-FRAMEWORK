using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class PedidoController : Controller
    {
        private ApplicationDbContext _contexto;

        public PedidoController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pedidos = _contexto.Pedido.ToList();
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            var pedido = _contexto.Pedido.First(c => c.Numero.Equals(id));
            return View("Salvar", pedido);
        }
        [HttpGet]
        public async Task<IActionResult> Deletar(string id)
        {
            var pedido = _contexto.Pedido.First(c => c.Numero.Equals(id));
            _contexto.Pedido.Remove(pedido);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Pedido pedidoPersist)
        {
            if (!string.IsNullOrEmpty(pedidoPersist.Numero))
            {
                var pedido = _contexto.Pedido.FirstOrDefault(c => c.Numero.Equals(pedidoPersist.Numero));
                if (pedido == null)
                {
                    _contexto.Pedido.Add(pedidoPersist);
                } else {
                    pedido.DataPedido = DateTime.Now;
                }
                await _contexto.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
