using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Models
{
    class CollectionView
    {
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

        [Display(Name = "Scadenta")]
        public DateTime Scadenta { get; set; }

        [Display(Name = "Scontare")]
        public string Scontare { get; set; }

        [Display(Name = "Girat")]
        public string Girat { get; set; }

        [Display(Name = "User")]
        public int? UserId { get; set; }
        
        [Display(Name = "Modificat de")]
        public int? UpdatedBy { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
