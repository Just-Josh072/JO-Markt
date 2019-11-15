using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class SubsubCategory
    {
        public SubCategory Subcategory { get; set; }
        public Category Categorie { get; set; }
        public int SubsubcategoryId { get; set; }
        public string Name { get; set; }
    }
}
