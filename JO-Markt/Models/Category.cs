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
        public string Naam { get; set; }
   
       // public int ProductId { get; set; }
        public ICollection<SubCategory> subcategories { get; set; }
      //  public ICollection<SubsubCategory> subsubcategories { get; set; }
       // public ICollection<Categories> Categories { get; set; }
        public ICollection<Product> Product { get; set; }
        public string Image { get; set; }
    }
}
