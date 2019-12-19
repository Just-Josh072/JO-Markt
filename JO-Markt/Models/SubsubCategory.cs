using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class SubsubCategory
    {
        public SubCategory Subcategory { get; set; }
        public Category Categorie { get; set; }
        [Key]
        public int SubsubcategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
