using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JO_Markt.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {

        }

        public string Geslacht { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Postcode { get; set; }
        public string Straat { get; set; }
        public double Huisnummer { get; set; }
        public string Toevoeging { get; set; }
        public int Telefoonnummer { get; set; }
        public DateTime? Geboortedatum { get; set; }
        public string Emailadres { get; set; }
        public string Wachtwoord { get; set; }
        public string Role { get; set; }
    }
}
