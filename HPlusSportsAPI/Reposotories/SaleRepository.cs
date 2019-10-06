using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Reposotories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly H_Plus_SportsContext context;

        public SaleRepository(H_Plus_SportsContext context)
        {
            this.context = context;
        }
        public void Add(Salesperson model)
        {
            this.context.Salesperson.Add(model);
            context.SaveChanges();
        }

        public Salesperson Find(int id) => context.Salesperson.Include(s => s.Order).SingleOrDefault(s => s.SalespersonId == id);

        public IEnumerable<Salesperson> GetAll() => context.Salesperson;

        public Salesperson Remove(int id)
        {
            Salesperson item = context.Salesperson.SingleOrDefault(s => s.SalespersonId == id);
            context.Salesperson.Remove(item);
            context.SaveChanges();
            return item;
        }

        public void Update(Salesperson model)
        {
            context.Salesperson.Update(model);
            context.SaveChanges();
        }
    }
}
