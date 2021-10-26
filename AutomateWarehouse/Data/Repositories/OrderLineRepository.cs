using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomateWarehouse.Data
{
  public class OrderLineRepository : IOrderLineRepository
  {
    private readonly ApplicationDbContext applicationDbContext;
    public OrderLineRepository(ApplicationDbContext context)
    {
      applicationDbContext = context;
    }

    /// <summary>
    /// Fetch the order lines for the selected order from the DB.
    /// </summary>
    /// <param name="currentOrder"></param>
    /// <returns> A list of all order lines </returns>
    public async Task<List<OrderLine>> GetCurrentOrderLinesAsync(Order currentOrder)
    {
      return await applicationDbContext.OrderLines.Where(o => o.OrderId == currentOrder.Id).ToListAsync();
    }

    /// <summary>
    /// Adds a new product (i.e. order line) to a order.
    /// </summary>
    /// <param name="orderLine"></param>
    /// <returns></returns>
    public async Task AddOrderLineAsync(OrderLine orderLine)
    {
      try
      {
        var OLinThisOrder = await applicationDbContext.OrderLines.Where(o => o.OrderId == orderLine.OrderId).ToListAsync();

        if (OLinThisOrder.Count() == 0)
        {
          applicationDbContext.OrderLines.Add(orderLine);
        }

        foreach (OrderLine ol in OLinThisOrder)
        {
          if (ol.ProductId == orderLine.ProductId)
          {
            ol.Quantity += orderLine.Quantity;
          }
          else
          {
            applicationDbContext.OrderLines.Add(orderLine);
          }
        }       
        await applicationDbContext.SaveChangesAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    /// <summary>
    /// Deletng customer from the database.
    /// </summary>
    /// <param name="customer">Customer to be deleted.</param>
    /// <returns></returns>
    public async Task DeleteOrderLineAsync(OrderLine orderLine)
    {
      try
      {
        applicationDbContext.Remove(orderLine);
        await applicationDbContext.SaveChangesAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
