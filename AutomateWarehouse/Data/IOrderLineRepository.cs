﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data
{
    interface IOrderLineRepository
    {
        Task<List<OrderLine>> GetCurrentOrderLinesAsync(Order order);
        Task<OrderLine> AddOrderLineAsync(OrderLine orderLine);
    }
}
