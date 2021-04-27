using System.ComponentModel.DataAnnotations;
using System;

namespace backend_uitleendienst.Models
{
    public class Lener
    {
        public Guid LenerId { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
