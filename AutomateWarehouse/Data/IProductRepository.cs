using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data
{
  interface IProductRepository
  {
        //int Id { get; set; }
        
        //string Name { get; set; }
        
        //string Description { get; set; }
        //double Price { get; set; }
        //int Stock { get; set; }
        //DateTime RestockingDate { get; set; }

        Task<List<Product>> GetAllProductsAsync();
        Task<Product> AddProductAsync(Product product);
        Task<Product> RemoveProductAsync(Product product);
        Task<Product> EditProductsAsync(Product product);

    }
}
