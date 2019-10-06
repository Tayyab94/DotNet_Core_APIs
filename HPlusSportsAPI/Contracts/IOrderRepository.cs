using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface IOrderRepository
    {
        void Add(Order model);
        void Update(Order model);
        IEnumerable<Order> GetAll();
        Order Find(int id);
        Order Remove(int id);
    }
}
