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
        [Required]
        [Range(0, 10000000000)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _description;
        private string _name;
        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}. ", MinimumLength = 3)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private double _price;
        [Required]

        [RegularExpression(@"\d+(\.\d{1,2})?")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Price must be greater than 0")]
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _stock;
        [Required]
        [Range(0, 99999)]
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        private DateTime _restockingDate;
        public DateTime RestockingDate
        {
            get { return _restockingDate; }
            set { _restockingDate = value; }
        }
    }
}
