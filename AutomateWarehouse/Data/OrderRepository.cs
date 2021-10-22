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

        /// <summary>
        /// Fetch a list with all order from the DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await applicationDbContext.Orders.ToListAsync();
        }

        /// <summary>
        /// Adds a new order to the DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> AddNewOrderAsync(Order order)
        {
            try
            {
                order.OrderDate = DateTime.Now;                   //Lägga till datumet på något annat ställe?
                applicationDbContext.Orders.Add(order);
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
            return order;
        }

        /// <summary>
        /// Edits an exisiting order in the DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> EditOrderAsync(Order order)
        {
            try
            {
                Order dbEntry = applicationDbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (dbEntry != null)
                {
                    dbEntry.DeliveryAddress = order.DeliveryAddress;
                    applicationDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }


        /// <summary>
        /// Sets an exisiting order to true (i.e. Paid)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sets an already paid order to false (i.e. undo payment)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> UndoPaymentAsync(Order order)
        {
            try
            {
                Order dbEntry = applicationDbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (dbEntry != null)
                {
                    dbEntry.PaymentCompleted = false;
                    await applicationDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }

        /// <summary>
        /// Sets an already dispatched order to false (i.e. undo dispatched)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> UndoDispatchAsync(Order order)
        {
            try
            {
                Order dbEntry = applicationDbContext.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (dbEntry != null)
                {
                    dbEntry.Dispatched = false;
                    await applicationDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }

        /// <summary>
        /// Processes all existing order that are checked as paid but not dispatched yet. (i.e. mark them as dispatched)
        /// </summary>
        /// <returns></returns>
        public async Task ProcessOrderAsync()
        {
            IEnumerable<Order> dbEntry = applicationDbContext.Orders.Where(o => o.PaymentCompleted == true &&
                o.Items.All(i => i.Quantity <= i.Product.Stock) && o.Dispatched == false);
            foreach(Order o in dbEntry)
            {

                foreach (OrderLine i in o.Items)
                {
                        i.Product.Stock -= i.Quantity;
                }
               
                o.Dispatched = true;
            }
            await applicationDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Filters the table to only show all dispatched orders.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAllDispatchedOrdersAsync()
        {
            //IEnumerable<Order> dbEntry =  applicationDbContext.Orders.Where(o => o.Dispatched==true);
            //return dbEntry.ToListAsync();
            return await applicationDbContext.Orders.Where(o => o.Dispatched == true).ToListAsync();
    }

        /// <summary>
        /// Filters the table to only show all pending orders.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAllPendingOrdersAsync()
        {
            IEnumerable<Order> dbEntry = applicationDbContext.Orders.Where(o => o.Dispatched==false);
            return dbEntry.ToList();
        }
    }
}
