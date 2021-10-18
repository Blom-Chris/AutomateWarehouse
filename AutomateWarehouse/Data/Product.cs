using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomateWarehouse.Data
{
  public class Product
  {
    public int Id { get; set; }
    private string _name;
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
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public DateTime RestockingDate { get; set; }
  }
}
