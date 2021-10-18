using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomateWarehouse.Data
{
  public class ProductRepository
  {
        private readonly ApplicationDbContext applicationDbContext;

        public ProductRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await applicationDbContext.Products.ToListAsync();
        }
    }
}
