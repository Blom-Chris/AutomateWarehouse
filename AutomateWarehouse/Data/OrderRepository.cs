using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data
{
  public class OrderRepository : IOrderRepository
  {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await applicationDbContext.Orders.ToListAsync();
        }

        public async Task<Order> AddNewOrderAsync(Order order)
        {
            try
            {
                applicationDbContext.Orders.Add(order);
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }



        public async Task<Order> PayOrderAsync(Order order)
        {
            try
            {
                Order dbEntry = applicationDbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
                if(dbEntry != null)
                {
                    dbEntry.PaymentCompleted = true;
                    await applicationDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }



        public async Task ProcessOrderAsync()
        {
            IEnumerable<Order> dbEntry = applicationDbContext.Orders.Where(o => o.PaymentCompleted == true &&
                o.Items.All(i => i.Quantity <= i.Product.Stock));
            foreach(Order o in dbEntry)
            {
                o.Dispatched = true;
            }
            await applicationDbContext.SaveChangesAsync();
        }



        public async Task<List<Order>> GetAllDispatchedOrdersAsync()
        {
            IEnumerable<Order> dbEntry = applicationDbContext.Orders.Where(o => o.Dispatched==true);
            return dbEntry.ToList();
        }



        public async Task<List<Order>> GetAllPendingOrdersAsync()
        {
            IEnumerable<Order> dbEntry = applicationDbContext.Orders.Where(o => o.Dispatched==false);
            return dbEntry.ToList();
        }


    }
}
