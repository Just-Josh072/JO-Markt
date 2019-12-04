using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class SubCategory
    {
        public Category Category { get; set; }
        public int SubcategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
