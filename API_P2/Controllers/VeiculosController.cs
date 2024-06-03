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
    public class VeiculosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public VeiculosController()
        {
            _dataContext = new DataContext();
        }

        [HttpPost]
        public ActionResult<Veiculos> Post([FromBody] Veiculos veiculos)
        {
            if (ModelState.IsValid)
            {
                var veiculos1 = veiculos;
                _dataContext.Veiculos.Add(veiculos1);
                _dataContext.SaveChanges();
                return veiculos1;
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public ActionResult<List<Veiculos>> Get()
        {
            var veiculos = _dataContext.Veiculos.ToList();
            return veiculos;
        }

        [HttpPut]
        public ActionResult<Veiculos> Put([FromBody] Veiculos veiculos)
        {
            var itemExistente = _dataContext.Veiculos.Any(i => i.Id == veiculos.Id);
            if (!itemExistente)
                ModelState.AddModelError("VeiculosId", "Id de veiculos não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Veiculos.Update(veiculos);
                _dataContext.SaveChanges();
                return veiculos;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var item = _dataContext.Veiculos.Find(id);
            if (item == null)
                ModelState.AddModelError("VeiculosId", "Id de Veiculos não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Veiculos.Remove(item);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}