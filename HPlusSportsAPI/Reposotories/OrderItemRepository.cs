using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Reposotories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly H_Plus_SportsContext context;

        public OrderItemRepository(H_Plus_SportsContext context)
        {
            this.context = context;
        }
        public void Add(OrderItem model)
        {
            context.OrderItem.Add(model);
            context.SaveChanges();
        }

        public OrderItem Find(int id) => context.OrderItem.Include(orderItem => orderItem.Order).Include(s=>s.Order)
            .Single(order => order.OrderId == id);

        public IEnumerable<OrderItem> GetAll() => context.OrderItem.Include(c => c.Order).Include(s=>s.Product).ToList();
       

        public OrderItem Remove(int id)
        {
            OrderItem item;
            item = context.OrderItem.Single(s => s.OrderItemId == id);
            context.OrderItem.Remove(item);
            context.SaveChanges();

            return item;
        }

        public void Update(OrderItem model)
        {
            context.OrderItem.Update(model);
            context.SaveChanges();
        }
    }
}
