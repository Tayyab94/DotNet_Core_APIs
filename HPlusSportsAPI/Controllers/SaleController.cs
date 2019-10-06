using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HPlusSportsAPI.Controllers
{
    [Route("api/[controller]")]
    public class SaleController : Controller

    {
        private readonly ISaleRepository saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Salesperson> Get()
        {
            return saleRepository.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="GetSalesPerson")]
        public IActionResult Get(int id)
        {
            var Item = saleRepository.Find(id);
            return new ObjectResult(Item);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Salesperson value)
        {
            saleRepository.Add(value);

            return CreatedAtRoute("GetSalesPerson", new { controller = "Sale", id = value.SalespersonId },value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Salesperson value)
        {
            var salePerson = saleRepository.Find(id);
            saleRepository.Update(value);

            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            saleRepository.Remove(id);

        }
    }
}
