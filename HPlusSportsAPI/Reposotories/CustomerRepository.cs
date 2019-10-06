using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Reposotories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly H_Plus_SportsContext _context;

        public CustomerRepository(H_Plus_SportsContext context)
        {
            this._context = context;
        }
        public void Add(Customer model)
        {
            _context.Customer.Add(model);
            _context.SaveChanges();

        }

        public Customer Find(int id)
        {
            return _context.Customer.Include(customer => customer.Order).Single(c => c.CustomerId == id);
        }

        public IEnumerable<Customer> GetAllCustomers() => _context.Customer.Include(s=>s.Order);
       
        public Customer Remove(int id)
        {
            Customer Item;
            Item = _context.Customer.Single(s => s.CustomerId == id);
            _context.Customer.Remove(Item);

            _context.SaveChanges();
            return Item;
        }

        public void Update(Customer item)
        {
            _context.Customer.Update(item);
            _context.SaveChanges();
        }
    }
}
