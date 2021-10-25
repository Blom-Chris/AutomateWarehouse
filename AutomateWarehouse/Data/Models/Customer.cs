using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutomateWarehouse.Data
{
  public class Customer
  {
    private int _id;
    [Required]
    [Range(0,10000000000)]
    public int Id 
    {
      get { return _id; }
      set { _id = value; }
    }

    private string _name;
    [Required]
    [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    private string _phone;
    [Required(ErrorMessage = "You must enter a phone number")]
    [RegularExpression(pattern: @"^[0]{1}[0-9]{1,3}-[0-9]{5,9}$", ErrorMessage = "The format for phone must follow: xxxx-xxxxxxxxx")]
    public string Phone 
    { 
      get { return _phone; }
      set { _phone = value; }
    }

    private string _email;
    [Required(ErrorMessage = "You must enter a email address")]
    [RegularExpression(pattern: @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Invalid email address.")]
    public string Email 
    { 
      get { return _email; }
      set { _email = value; }        
    }

    private List<Order> _order;
    public List<Order> Orders 
    { 
      get { return _order; }
      set { _order = value; }
    } 
  }
}
