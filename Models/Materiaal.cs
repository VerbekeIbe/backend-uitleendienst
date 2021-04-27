using System;
using System.ComponentModel.DataAnnotations;

namespace backend_uitleendienst.Models
{
    public class Materiaal
    {

        [Required]
        public Guid MateriaalId { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string Categorie { get; set; }
        public int Drempel { get; set; }
        
    }
}
