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
    public int Id { get; private set; }

    private int _CustomerId;
    public int CustomerId
    {
            get
            {
                return _CustomerId;
            }
            set
            {
                _CustomerId = value;
            }
    }

    private Customer _Customer;
    public Customer Customer
    {
            get
            {
                return _Customer;
            }
            set
            {
                _Customer = value;
            }
    }

    private DateTime _OrderDate;
    public DateTime OrderDate
    {
        get
        {
            return _OrderDate;
        }
        set
        {
            _OrderDate = value;
        }
    }

    private string _DeliveryAddress;
    [Required]
    [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 7)]
    public string DeliveryAddress 
    {
            get
            {
                return _DeliveryAddress;
            }
            set
            {
                _DeliveryAddress = value;
            } 
    }

    private bool _PaymentCompleted;
    public bool PaymentCompleted
    {
            get
            {
                return _PaymentCompleted;
            }
            set
            {
                _PaymentCompleted = value;
            }
    }

    private bool _Dispatched;
    public bool Dispatched
        {
            get
            {
                return _Dispatched;
            }
            set
            {
                _Dispatched = value;
            }
        }

    private List<OrderLine> _Items; 
    public List<OrderLine> Items
    {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
            }
    }
  }
}
