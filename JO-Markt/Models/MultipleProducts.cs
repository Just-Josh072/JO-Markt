﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOMarkt.Models;

namespace JOMarkt.Models
{
    public class MultipleProducts
    {
        public List<Product> Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<Product> RelatedCategory { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
    }
}
