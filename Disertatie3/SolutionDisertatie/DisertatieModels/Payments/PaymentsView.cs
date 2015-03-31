using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Models
{
    class PaymentsView
    {
        [Display(Name = "Platit")]
        public bool Platit { get; set; }

        [Display(Name = "Catre")]
        public string Catre { get; set; }

        [Display(Name = "Document plata")]
        public string DocumentPlata { get; set; }

        [Display(Name = "Factura")]
        public string Factura { get; set; }

        [Display(Name = "Valoare")]
        public int Valoare { get; set; }

        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "User")]
        public int? UserId { get; set; }
        
        [Display(Name = "Modificat de")]
        public int? UpdatedBy { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
