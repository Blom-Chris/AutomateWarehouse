using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data
{
  interface IOrderLineRepository
  {
    Task<List<OrderLine>> GetCurrentOrderLinesAsync(Order order);
    Task AddOrderLineAsync(OrderLine orderLine);
    Task DeleteOrderLineAsync(OrderLine orderLine);
  }
}
