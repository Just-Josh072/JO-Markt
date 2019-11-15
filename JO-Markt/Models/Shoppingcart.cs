﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class Shoppingcart
    {
    }
    public class ShoppingCartViewModel
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public double Price { get; set; }
        public double TotalPrice
        {
            get
            {
                return Price * Amount;
            }
        }

        public string Name { get; set; }
        public string Image { get; set; }
    }
}
