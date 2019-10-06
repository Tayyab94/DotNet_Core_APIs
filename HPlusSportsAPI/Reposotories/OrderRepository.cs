using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Reposotories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly H_Plus_SportsContext context;

        public OrderRepository(H_Plus_SportsContext context)
        {
            this.context = context;
        }

        public void Add(Order model)
        {
            context.Order.Add(model);
            context.SaveChanges();
        }

        public Order Find(int id)
        {
            return context.Order.Include(s => s.Customer).Include(s => s.OrderItem).Include(s => s.Salesperson).Single(s => s.OrderId.Equals(id));
        }

        public IEnumerable<Order> GetAll() => context.Order;

        public Order Remove(int id)
        {
            Order item = context.Order.Single(s => s.OrderId.Equals(id));
            context.Order.Remove(item);
            context.SaveChanges();

            return item;
        }

        public void Update(Order model)
        {
            context.Order.Update(model
                );
            context.SaveChanges();
        }
    }
}
