using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class Categories
    {
        public int id { get; set; }
        [NotMapped]
        public ICollection<Category> categorie { get; set; }
        public ICollection<SubCategory> subcategory { get; set; }
        public ICollection<SubsubCategory> subsubcategory { get; set; }
    }
}
