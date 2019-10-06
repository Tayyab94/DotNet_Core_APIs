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
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;


        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(string id)
        {
            var Item = productRepository.Find(id);

            return new ObjectResult(Item);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Product value)
        {
            productRepository.Add(value);
            return CreatedAtRoute("GetProduct", new { controller = "Product", id = value.ProductId }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product value)
        {
            productRepository.Update(value);

            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            productRepository.Remove(id);
        }
    }
}
