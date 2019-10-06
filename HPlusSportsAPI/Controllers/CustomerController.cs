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
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository CustomerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.CustomerRepository = customerRepository;
        }


        [HttpGet]
        public IEnumerable<Customer> GetAll() => CustomerRepository.GetAllCustomers();


        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var Item = CustomerRepository.Find(id);

            return new ObjectResult(Item);
        }


        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (customer == null)
                return BadRequest();
            TryValidateModel(customer);
            if (ModelState.IsValid)
            {
                CustomerRepository.Add(customer);
            }
            else
            {
                return BadRequest();
            }
        

            return CreatedAtRoute("GetCustomer", new { Controller = "Customer", id = customer.CustomerId }, customer);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            var Customer = CustomerRepository.Find(id);
            CustomerRepository.Update(Customer);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id <= 0)
                CustomerRepository.Remove(id);
          
        }

    }
}
