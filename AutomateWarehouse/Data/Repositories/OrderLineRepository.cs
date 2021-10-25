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
                applicationDbContext.OrderLines.Add(orderLine);
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
