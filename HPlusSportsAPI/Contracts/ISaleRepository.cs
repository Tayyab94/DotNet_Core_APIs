using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface ISaleRepository
    {

        void Add(Salesperson model);
        void Update(Salesperson model);
        IEnumerable<Salesperson> GetAll();

        Salesperson Find(int id);

        Salesperson Remove(int id);

    }
}
