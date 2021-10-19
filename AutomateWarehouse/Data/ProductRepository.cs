using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomateWarehouse.Data
{
  public class ProductRepository
    {
        private ApplicationDbContext applicationDbContext { get; set; }
        List<Product> productList { get; set; }

        public ProductRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;
            productList = new List<Product>();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await applicationDbContext.Products.ToListAsync();
        }
        
        public void AddProducts(Product p)
        {
            productList.Add(p);
        }
        public void RemoveProducts(Product p)
        {
            productList.Remove(p);
        }
        Product updatedProduct = new Product();
        private void SetProductForUpdates(Product selected)
        {
            updatedProduct = selected;
        }
        private void UpdateProduct()
        {
            //catalogueService.UpdateProduct(updatedProduct);
        }
        public async Task<List<Product>> EmptyStock()
        {
            IEnumerable<Product> result = applicationDbContext.Products.Where(a => a.Stock < 1);
            return result.ToList();
        }
       
    }
}
