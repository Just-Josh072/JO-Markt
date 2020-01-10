using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }
    }
}
