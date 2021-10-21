using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutomateWarehouse.Data
{
    public class OrderLine
    {
        /// <summary>
        /// Property for OrderLine.Id, autoincrement in DB.
        /// </summary>
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }


        private Product _product;
        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private int _orderId;
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private Order _order;
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
        }

        private int _quantity;
        [Required]
        [Range(0, 9999)]
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}
