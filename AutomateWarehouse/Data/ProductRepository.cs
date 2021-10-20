using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomateWarehouse.Data
{
  public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        //List<Product> productList { get; set; }

        public ProductRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;
            //productList = new List<Product>();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await applicationDbContext.Products.ToListAsync();
        }
        public async Task<Product> AddProductAsync(Product p)
        {
            try
            {
                await SetRestockDate(p);
                applicationDbContext.Products.Add(p);
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
            return p;
        }

        public async Task<Product> RemoveProductAsync(Product p)
        {
            try
            {
                applicationDbContext.Remove(p);
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
            return p;
        }

        public async Task<Product> EditProductsAsync(Product product)
        {
            try
            {
                Product dbEntry = applicationDbContext.Products.FirstOrDefault(a => a.Id == product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Stock = product.Stock;
                    dbEntry.RestockingDate = product.RestockingDate;
                    applicationDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        
        public async Task<List<Product>> EmptyStock()
        {
            IEnumerable<Product> result = applicationDbContext.Products.Where(a => a.Stock < 1);
            return result.ToList();
        }
        public async Task<Product> SetRestockDate(Product p)
        {
            if(p.Stock == 0)
            {
                p.RestockingDate = DateTime.Today.AddDays(10);
                
            }
            return p;
        }
    }
}
