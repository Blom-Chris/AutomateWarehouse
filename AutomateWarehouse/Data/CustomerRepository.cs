using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly ApplicationDbContext applicationDbContext;

    public CustomerRepository(ApplicationDbContext context)
    {
      applicationDbContext = context;
    }
    public async Task<List<Customer>> GetCustomerAsync()
    {
      return await applicationDbContext.Customers.ToListAsync();
    }

    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
      try
      {
        applicationDbContext.Customers.Add(customer);
        await applicationDbContext.SaveChangesAsync();
      }
      catch (Exception e)
      {
        throw;
      }
      return customer;
    }

    public async Task<Customer> DeleteCustomerAsync(Customer customer)
    {
      try
      {
        applicationDbContext.Remove(customer);
        await  applicationDbContext.SaveChangesAsync();
      }
      catch (Exception e)
      {
        throw;
      }
      return customer;
    }

    public async Task<Customer> EditCustomerAsync(Customer customer)
    {
      try
      {
        Customer dbEntry = applicationDbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
        if (dbEntry != null)
        {
          dbEntry.Name = customer.Name;
          dbEntry.Phone = customer.Phone;
          dbEntry.Email = customer.Email;
          applicationDbContext.SaveChanges();
        }
      }
      catch (Exception)
      {
        throw;
      }
      return customer;
    }

    public async Task<List<Order>> ShowDispatchedOrdersByCustomer(Customer customer)
    {
      return await applicationDbContext.Orders.Where(o => o.Dispatched == true).Where(p => p.CustomerId == customer.Id).ToListAsync();
    }
  }
}
