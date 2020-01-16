using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
   
    public class CartItemViewModel
    {
        public int ProductId { get; set; }

        public double Price { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Amount { get; set; }
        public double TotalPrice
        {
            get
            {
                return Price * Amount;
            }
        }

    }
}
