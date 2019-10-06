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
    public class OrderItemController : Controller
    {
        private  IOrderItemRepository orderItemRepository{ get; set; }

        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<OrderItem> Get() => orderItemRepository.GetAll();

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="GetOrderItem")]
        public IActionResult Get(int id)
        {
            var item = orderItemRepository.Find(id);
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]OrderItem value)
        {
            orderItemRepository.Add(value);
            return CreatedAtRoute("GetOrderItem", new { controller = "OrderItem", id = value.OrderItemId }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderItem value)
        {
            orderItemRepository.Update(value);

            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderItemRepository.Remove(id);
        }
    }
}
