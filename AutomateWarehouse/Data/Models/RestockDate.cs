using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data.Models
{
    public class RestockDate
    {
        readonly Product product = new();
        public RestockDate(Product p)
        {
            product = p;
            SetRestockDate(product);
        }

        /// <summary>
        /// Sets the restocking date for a product to today +10 if its out of stock.
        /// If its not, it gets a default value which shows as n/a in the table.
        /// </summary>
        /// <param name="p"></param>
        public void SetRestockDate(Product p)
        {
            if (p.Stock == 0)
            {
                p.RestockingDate = DateTime.Today.AddDays(10);
            }
        }
    }
}
