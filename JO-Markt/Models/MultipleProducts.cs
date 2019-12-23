using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOMarkt.Models;

namespace JOMarkt.Models
{
    public class MultipleProducts
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<Product> RelatedCategory { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
    }
}
