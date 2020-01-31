using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }
        public double TotalPrice { get; set; }
        public double TotalAmount { get; set; }

        [Required]
        public string Naam { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Stad { get; set; }
    }
}
