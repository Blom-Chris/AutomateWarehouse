using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomateWarehouse.Data
{
  interface IOrderRepository 
  {

        Task<Order> AddNewOrderAsync(Order order);
        Task<Order> PayOrderAsync(Order order);
        Task<Order> EditOrderAsync(Order order);
        Task<Order> UndoPaymentAsync(Order order);
        Task<Order> UndoDispatchAsync(Order order);
        Task ProcessOrderAsync();
        Task<List<Order>> GetAllDispatchedOrdersAsync();
        Task<List<Order>> GetAllPendingOrdersAsync();
        Task<List<Order>> GetAllOrdersAsync();
    }
}
