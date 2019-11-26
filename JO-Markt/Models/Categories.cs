using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class Categories
    {   [Key]
        public List<Category> categorie { get; set; }
        public List<SubCategory> subcategory { get; set; }
        public List<SubsubCategory> subsubcategory { get; set; }
    }
}
