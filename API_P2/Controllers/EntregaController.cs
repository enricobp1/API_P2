using Microsoft.AspNetCore.Mvc;
using API_P2.Context;
using API_P2.DTO;
using API_P2.Model;
using System.Collections.Generic;
using System.Linq;

namespace API_P2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregaController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EntregaController()
        {
            _dataContext = new DataContext();
        }

        [HttpPost]
        public ActionResult<Entrega> Post([FromBody] EntregaRequest entregaRequest)
        {
            if (ModelState.IsValid)
            {
                var entrega = entregaRequest.toModel();
                _dataContext.Entrega.Add(entrega);
                _dataContext.SaveChanges();
                return entrega;
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public ActionResult<List<Entrega>> Get()
        {
            var entrega = _dataContext.Entrega.ToList();
            return entrega;
        }

        [HttpPut]
        public ActionResult<Entrega> Put([FromBody] Entrega entrega)
        {
            var itemExistente = _dataContext.Entrega.Any(i => i.Id == entrega.Id);
            if (!itemExistente)
                ModelState.AddModelError("EntregaId", "Id de Entrega não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Entrega.Update(entrega);
                _dataContext.SaveChanges();
                return entrega;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var item = _dataContext.Entrega.Find(id);
            if (item == null)
                ModelState.AddModelError("EntregaId", "Id de Entrega não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Entrega.Remove(item);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}