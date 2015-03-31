using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Models
{
    class ConsumptionView
    {
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Materie")]
        public int? MaterieId { get; set; }
        public virtual RawMaterials Materii { get; set; }

        [Display(Name = "User")]
        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [Display(Name = "Cantitate")]
        public int Cantitate { get; set; }
    }
}
