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

        public ProductRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        /// <summary>
        /// Fetch a list with all products from the DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await applicationDbContext.Products.ToListAsync();
        }

        /// <summary>
        /// Adds a new product to the DB. Also sets the restocking date for the product.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<Product> AddProductAsync(Product p)
        {
            try
            {
                SetRestockDate(p);
                applicationDbContext.Products.Add(p);
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
            return p;
        }

        /// <summary>
        /// Deletes a product from the DB.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Edits the values of a already existing product in the DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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
                    await applicationDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        /// <summary>
        /// Returns a list with products that are out of stock.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> EmptyStock()
        {
            IEnumerable<Product> result = await applicationDbContext.Products.Where(a => a.Stock < 1).ToListAsync();
            return result.ToList();
        }

        /// <summary>
        /// Sets the restocking date for a product to today +10 if its out of stock.
        /// If its not, it gets a default value which shows as n/a in the table.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Product SetRestockDate(Product p)
        {
            if(p.Stock == 0)
            {
                p.RestockingDate = DateTime.Today.AddDays(10);
                
            }
            return p;
        }
    }
}
