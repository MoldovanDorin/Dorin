using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisertatieModels.Models
{
    public class Collections
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Incasat")]
        public bool Incasat { get; set; }

        [Display(Name = "De la")]
        public string DeLa { get; set; }

        public DateTime Data { get; set; }

        [Display(Name = "Factura incasata")]
        public string FacturaInc { get; set; }

        [Display(Name = "Document incasat")]
        public string DocumentInc { get; set; }

        [Display(Name = "Valoare incasata")]
        public int ValoareInc { get; set; }

        public DateTime Scadenta { get; set; }

        public string Scontare { get; set; }

        public string Girat { get; set; }

        public int? UserId { get; set; }
        
        public int? UpdatedBy { get; set; }

        public virtual UserProfile UserProfile { get; set; }

    }
}