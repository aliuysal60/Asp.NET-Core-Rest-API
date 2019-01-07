using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("[controller]")]
    public class ProductionOrderController : Controller
    {
        private readonly IProductionOrderRepository _productionorderRepository;


        public ProductionOrderController(IProductionOrderRepository productionorderRepository)
        {
            _productionorderRepository = productionorderRepository;
        }


        // GET: book
        [HttpGet]
        public IEnumerable<ProductionOrder> Get()
        {
            return _productionorderRepository.GetAll();
        }


        // GET book/5
        [HttpGet("{id}", Name = "GetProductionOrder")]
        public IActionResult Get(int id)
        {
            var productionorder = _productionorderRepository.GetById(id);
            if (productionorder == null)
            {
                return NotFound();
            }

            return Ok(productionorder);
        }


        // POST book
        [HttpPost]
        public IActionResult Post([FromBody]ProductionOrder value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var createdProductionOrder = _productionorderRepository.Add(value);


            return CreatedAtRoute("GetProductionOrder", new { id = createdProductionOrder.Id }, createdProductionOrder);
        }


        // PUT book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProductionOrder value)
        {
            if (value == null)
            {
                return BadRequest();
            }


            var note = _productionorderRepository.GetById(id);


            if (note == null)
            {
                return NotFound();
            }


            value.Id = id;
            _productionorderRepository.Update(value);


            return NoContent();


        }


        // DELETE book/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productionorder = _productionorderRepository.GetById(id);
            if (productionorder == null)
            {
                return NotFound();
            }
            _productionorderRepository.Delete(productionorder);


            return NoContent();
        }


    }

}
