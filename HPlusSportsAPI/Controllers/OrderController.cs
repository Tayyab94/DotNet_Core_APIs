using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSportsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll() => orderRepository.GetAll();

        [HttpGet("{id}",Name ="GetOrder")]
        public IActionResult Get(int id)
        {
            var Order = orderRepository.Find(id);

            return new ObjectResult(Order);
        }


        [HttpPost]
        public IActionResult Post([FromBody]Order model)
        {
            orderRepository.Add(model);

            return CreatedAtRoute("GetOrder", new { Controller = "Order", id = model.OrderId }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Order model)
        {
            var order = orderRepository.Find(id);
            orderRepository.Update(model);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
       public void Delete(int id)
        {
            orderRepository.Remove(id);
        }
    }
}