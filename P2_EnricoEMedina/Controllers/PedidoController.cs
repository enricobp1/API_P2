using Microsoft.AspNetCore.Mvc;
using P2_EnricoEMedina.Context;
using P2_EnricoEMedina.DTO;
using P2_EnricoEMedina.Model;
using System.Collections.Generic;
using System.Linq;

namespace P2_EnricoEMedina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PedidoController()
        {
            _dataContext = new DataContext();
        }

        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] PedidoRequest pedidoRequest)
        {
            if (ModelState.IsValid)
            {
                var itemPedido = _dataContext.ItemPedido.Find(pedidoRequest.ItemId);
                if (itemPedido == null)
                {
                    ModelState.AddModelError("ItemPedidoId", "O ItemPedidoId fornecido não existe.");
                    return BadRequest(ModelState);
                }

                var pedido = pedidoRequest.ToModel();
                _dataContext.Pedido.Add(pedido);
                _dataContext.SaveChanges();
                return pedido;
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            var pedido = _dataContext.Pedido.ToList();
            return pedido;
        }

        [HttpPut]
        public ActionResult<Pedido> Put([FromBody] Pedido pedido)
        {
            var pedidoExistente = _dataContext.Pedido.Any(p => p.Id == pedido.Id);
            if (!pedidoExistente)
                ModelState.AddModelError("PedidoId", "Id de pedido não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Pedido.Update(pedido);
                _dataContext.SaveChanges();
                return pedido;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var pedido = _dataContext.Pedido.Find(id);
            if (pedido == null)
                ModelState.AddModelError("PedidoId", "Id de pedido não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Pedido.Remove(pedido);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
