using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Contracts
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product model);

        IEnumerable<Product> GetAll();

        Product Find(string id);

        Product Remove(string id);
    }
}
