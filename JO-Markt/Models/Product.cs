using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using JOMarkt.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOMarkt.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string EAN { get; set; }

        public string Title { get; set; }
        public string Brand { get; set; }
        public string Shortdescription { get; set; }
        public string Fulldescription { get; set; }
        public string Image { get; set; }
        public string Weight { get; set; }
        public double Price { get; set; }
        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       // [ForeignKey("SubcategoryId")]
        public int SubcategoryId { get; set; }
        public SubCategory Subcategory { get; set; }
      //  public string Subsubcategory { get; set; }
       

    }
}
