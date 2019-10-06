using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface IOrderItemRepository
    {

        void Add(OrderItem model);

        void Update(OrderItem model);

        IEnumerable<OrderItem> GetAll();

        OrderItem Find(int id);

        OrderItem Remove(int id);
    }
}
