using System;
using System.ComponentModel.DataAnnotations;

namespace backend_uitleendienst.Models
{
    public class Lening
    {

        public Guid LeningId { get; set; }
       
        public DateTime Date { get; set; }

        [Required]
        public int Hoeveelheid { get; set; }

        public bool Pending { get; set; }

        [Required]
        public Guid MateriaalId { get; set; }

        [Required]
        public Guid LenerId { get; set; }
    }
}
