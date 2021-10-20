using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutomateWarehouse.Data
{
  public class Product
    {
    
    public int Id { get; set; }
    private string _name;
    private double _price;

    [Required]
    [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}. ", MinimumLength = 3)]
    public string Name
    {
      get {return _name;}
      set {_name = value;}
    }
    public string Description { get; set; }
    [Required]
    [Range(1, 9999)]
    public double Price { get { return _price; } set { _price = value; } }
    [Required]
    [Range(0, 9999)]
        public int Stock { get; set; }
        public DateTime _dateTime = DateTime.Today;
    public DateTime RestockingDate { get; set; }
  }

}
