using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutomateWarehouse.Data
{
  public class Customer
  {
    public int Id { get; set; }

    private string _name;
    [Required]
    [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }

    private string _phone;
    [Required(ErrorMessage = "Du måste fylla i ditt mobiltelefonnummer")]
    [RegularExpression(pattern: @"^[0]{1}[0-9]{1,3}-[0-9]{5,9}$", ErrorMessage = "Formatet för mobilnummer ska vara xxxx-xxxxxxxxx")]
    public string Phone 
    { get
      {
        return _phone;
      }
       set
      {
        _phone = value;
      }
    }

    private string _email;
    [Required]
    [RegularExpression(pattern: @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Fel format för email.")]
    public string Email 
    { 
      get
      {
        return _email;
      }
        set
      {
        _email = value;
      }        
    }

    public List<Order> Orders { get; set; } 
  }
}
