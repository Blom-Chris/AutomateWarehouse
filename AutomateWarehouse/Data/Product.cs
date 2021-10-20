using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutomateWarehouse.Data
{
  public class Product
    {

    private int _id;
    private string _name;
    private double _price;
    private string _description;
    private int _stock;
    private DateTime _restockingDate;

    [Required]
    [Range(0, 10000000000)]
    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    [Required]
    [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}. ", MinimumLength = 3)]
    public string Name
    {
      get {return _name;}
      set {_name = value;}
    }

    public string Description 
    {
      get { return _description; }
      set { _description = value; }
    }

    [Required]
    [Range(1, 9999)]
    public double Price 
    {
      get { return _price; }
      set { _price = value; }
    }

    [Required]
    [Range(0, 9999)]
    public int Stock 
    {
      get { return _stock; }
      set { _stock = value; }
    }

    public DateTime RestockingDate
    {
      get { return _restockingDate; }
      set { _restockingDate = value; }
    }


    //    public DateTime _dateTime = DateTime.Today;
    //public DateTime RestockingDate {
    //        get
    //        {
    //            return _dateTime;
    //        }
    //        set {
    //            if (Stock == 0)
    //            {
    //                _dateTime =_dateTime.AddDays(10);
    //            }

    //        }
    //         }
  }

}
