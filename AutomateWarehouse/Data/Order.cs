using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutomateWarehouse.Data
{
  public class Order
  {
    private int _id;
    [Required]
    [Range(0, 10000000000)]
    public int Id 
    {
      get
      {
        return _id;
      }
      set
      {
        _id = value;
      }
    }
    private int _customerId;
    public int CustomerId 
    {
      get
      {
        return _customerId;
      }
      set
      {
        _customerId = value;
      }
    }
    private Customer _customer;
    public Customer Customer 
    {
      get
      {
        return _customer;
      }
      set
      {
        _customer = value;
      }
    }
    private DateTime _orderDate;
    public DateTime OrderDate 
    {
      get
      {
        return _orderDate;
      }
      set
      {
        _orderDate = value;
      }
    }
    private string _deliveryAddress;
    [Required]
    public string DeliveryAddress 
    {
      get
      {
        return _deliveryAddress;
      }
      set
      {
        _deliveryAddress = value;
      }
    }
    private bool _paymentCompleted;
    public bool PaymentCompleted 
    {
      get
      {
        return _paymentCompleted;
      }
      set
      {
        _paymentCompleted = value;
      }
    }
    private bool _dispatched;
    public bool Dispatched 
    {
      get
      {
        return _dispatched;
      }
      set
      {
        _dispatched = value;
      }
    }
    private List<OrderLine> _items;
    public List<OrderLine> Items 
    {
      get
      {
        return _items;
      }
      set
      {
        _items = value;
      }
    }
  }
}
