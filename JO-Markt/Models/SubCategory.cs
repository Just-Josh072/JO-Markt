using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class SubCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
      
        [Key]
        public int SubcategoryId { get; set; }
       
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Product> Products { get; set; }
    }
}
