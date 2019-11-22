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
        public int Id { get; set; }

        public string EAN { get; set; }

        public string Title { get; set; }
        public string Brand { get; set; }
        public string Shortdescription { get; set; }
        public string Fulldescription { get; set; }
        public string Image { get; set; }
        public string Weight { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
   [NotMapped]
        public object Subsubcategory { get; set; }
       
    }
}
