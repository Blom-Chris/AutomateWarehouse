using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data
{
  interface IProductRepository
  {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> AddProductAsync(Product product);
        Task<Product> RemoveProductAsync(Product product);
        Task<Product> EditProductsAsync(Product product);
        Task<List<Product>> EmptyStock();
    }
}
