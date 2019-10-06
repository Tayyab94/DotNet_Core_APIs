using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface ICustomerRepository
    {
        void Add(Customer model);

        IEnumerable<Customer> GetAllCustomers();

        Customer Find(int id);

        Customer Remove(int id);

        void Update(Customer item);
    }
}
