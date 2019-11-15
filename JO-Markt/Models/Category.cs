using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class Category
    {
        public int CategorieId { get; set; }
        public string Name { get; set; }
        public List<SubCategory> subcategories { get; set; }
        public List<SubsubCategory> subsubcategories { get; set; }
    }
}
