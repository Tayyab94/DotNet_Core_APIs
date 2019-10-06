using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Reposotories
{
    public class ProductRepository : IProductRepository
    {
        private readonly H_Plus_SportsContext context;
        private readonly IMemoryCache cache;

        public ProductRepository(H_Plus_SportsContext context, IMemoryCache cache)
        {
            this.context = context;
            this.cache = cache;
        }
        public void Add(Product product)
        {
            context.Product.Add(product);
            cache.Set(product.ProductId, product, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
            context.SaveChanges();
        }

        public Product Find(string id)
        {
            Product cacheProduct = null;
            if(cache.TryGetValue(id,out cacheProduct))
            {
                return cacheProduct;
            }
            else
            {
                return context.Product.Include(s => s.OrderItem).SingleOrDefault(s => s.ProductId == id);
            }
            
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Product;
        }

        public Product Remove(string id)
        {
            Product item = context.Product.SingleOrDefault(s => s.ProductId.Equals(id));
            context.Product.Remove(item);
            context.SaveChanges();
            return item;
        }

        public void Update(Product model)
        {
            context.Product.Update(model);
            context.SaveChanges();
        }
    }
}
