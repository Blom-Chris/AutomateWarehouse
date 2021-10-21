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
                //UpdateProductStock(o);
            }
            await applicationDbContext.SaveChangesAsync();
        }

        //public async Task UpdateProductStock(Order o)
        //{
        //    try
        //    {
        //        foreach (OrderLine orderLine in o.Items)
        //        {
        //            Product dbEntry = applicationDbContext.Products.FirstOrDefault(p => p.Id == orderLine.ProductId);
        //            if (dbEntry != null)
        //            {
        //                dbEntry.Stock -= orderLine.Quantity;
        //                await applicationDbContext.SaveChangesAsync();
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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
