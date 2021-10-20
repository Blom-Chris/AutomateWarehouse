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

        //Behövs inte
        public async Task<List<OrderLine>> GetAllOrderLinesAsync()
        {
            return await applicationDbContext.OrderLines.ToListAsync();
        }

        public async Task<List<OrderLine>> GetCurrentOrderLinesAsync(Order currentOrder)
        {
            return await applicationDbContext.OrderLines.Where(o => o.OrderId == currentOrder.Id).ToListAsync();
        }

        public async Task<OrderLine> AddOrderLineAsync(OrderLine orderLine)
        {
            try
            {
                applicationDbContext.OrderLines.Add(orderLine);
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
            return orderLine;
        }
    }
}
