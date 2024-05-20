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
    public class ItemController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ItemController()
        {
            _dataContext = new DataContext();
        }

        [HttpPost]
        public ActionResult<ItemPedido> Post([FromBody] ItemRequest itemRequest)
        {
            if (ModelState.IsValid)
            {
                var item = itemRequest.toModel();
                _dataContext.ItemPedido.Add(item);
                _dataContext.SaveChanges();
                return item;
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public ActionResult<List<ItemPedido>> Get()
        {
            var itens = _dataContext.ItemPedido.ToList();
            return itens;
        }

        [HttpPut]
        public ActionResult<ItemPedido> Put([FromBody] ItemPedido item)
        {
            var itemExistente = _dataContext.ItemPedido.Any(i => i.Id == item.Id);
            if (!itemExistente)
                ModelState.AddModelError("ItemId", "Id de item não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.ItemPedido.Update(item);
                _dataContext.SaveChanges();
                return item;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var item = _dataContext.ItemPedido.Find(id);
            if (item == null)
                ModelState.AddModelError("ItemId", "Id de item não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.ItemPedido.Remove(item);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
