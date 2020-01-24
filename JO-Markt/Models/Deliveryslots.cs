using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOMarkt.Models
{
    public class Deliveryslots
    {
        [Key]
        public int DeliveryslotId { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double Price { get; set; }
        public bool IsChecked { get; set; }

    }
}
