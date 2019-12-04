using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class Category
    {
        [Key]
        public int CategorieId { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public ICollection<SubCategory> subcategories { get; set; }
        public ICollection<SubsubCategory> subsubcategories { get; set; }
        public ICollection<Categories> Categories { get; set; }
        public string Image { get; set; }
    }
}
