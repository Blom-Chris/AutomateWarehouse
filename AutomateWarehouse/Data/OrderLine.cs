using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutomateWarehouse.Data
{
  public class OrderLine
    {
    private int _id;
    private int _productId;
    private Product _product;
    private int _orderId;
    private Order _order;
    private int _quantity;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public int ProductId
    {
        get { return _productId; }
        set { _productId = value; }
    }

    public Product Product 
    {
        get { return _product; }
        set { _product = value; }
    }

    public int OrderId
    {
        get { return _orderId; }
        set { _orderId = value; }
    }

    public Order Order 
    {
        get { return _order; } 
        set { _order = value; }
    }

    [Required]
    [Range(0, 9999)]
    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }
  }
}
