using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisertatieModels.Models
{
    public class Payments
    {
        [Required]
        public int Id { get; set; }

        public bool Platit { get; set; }

        public string Catre { get; set; }

        public string DocumentPlata { get; set; }

        public string Factura { get; set; }

        public int Valoare { get; set; }

        public DateTime Data { get; set; }

        public int? UserId { get; set; }       

        public int? UpdatedBy { get; set; }

        public virtual UserProfile UserProfile { get; set; }
       
    }
}