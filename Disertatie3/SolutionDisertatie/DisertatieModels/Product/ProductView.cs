using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Models
{
    class ProductView
    {
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Display(Name = "Sters ")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Adaugat de ")]
        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
