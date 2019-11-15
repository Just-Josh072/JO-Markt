using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class Promotions
    {
        public string Title { get; set; }

        [Key]
        public int Discount_Id { get; set; }

        [ForeignKey("Products")]
        public string EAN { get; set; }

        public double DiscountPrice { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
