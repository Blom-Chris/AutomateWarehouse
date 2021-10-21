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

    /// <summary>
    /// Fetching all customer from the database.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Customer>> GetCustomerAsync()
    {
      return await applicationDbContext.Customers.ToListAsync();
    }

    /// <summary>
    /// Adding customer to database.
    /// </summary>
    /// <param name="customer">Customer to add to database.</param>
    /// <returns></returns>
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

    /// <summary>
    /// Deletng customer from the database.
    /// </summary>
    /// <param name="customer">Customer to be deleted.</param>
    /// <returns></returns>
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

    /// <summary>
    /// Edit selected customer in the database.
    /// </summary>
    /// <param name="customer">Customer to be edited.</param>
    /// <returns></returns>
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

    /// <summary>
    /// For showing the orders that are dispatched by customer.
    /// </summary>
    /// <param name="customer">Customer whos orders are dispatched.</param>
    /// <returns></returns>
    public async Task<List<Order>> ShowDispatchedOrdersByCustomer(Customer customer)
    {
      return await applicationDbContext.Orders.Where(o => o.Dispatched == true).Where(p => p.CustomerId == customer.Id).ToListAsync();
    }

    /// <summary>
    /// Show active orders for certain customer.
    /// </summary>
    /// <param name="customer">Customer whos order are active.</param>
    /// <returns></returns>
    public async Task<List<Order>> ShowActiveOrdersByCustomer(Customer customer)
    {
      return await applicationDbContext.Orders.Where(o => o.Dispatched == false).Where(p => p.CustomerId == customer.Id).ToListAsync();
    }
  }
}
