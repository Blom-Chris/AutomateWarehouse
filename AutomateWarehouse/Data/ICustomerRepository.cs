using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data
{
  interface ICustomerRepository
  {
    Task<List<Customer>> GetCustomerAsync();
    Task<Customer> AddCustomerAsync(Customer customer);
    Task<Customer> DeleteCustomerAsync(Customer customer);
    Task<Customer> EditCustomerAsync(Customer customer);

  }
}
