using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Models
{
    class RecipesView
    {
        [Display(Name = "Produs")]
        public int? ProdusId { get; set; }
        public virtual Product Produse { get; set; }

        [Display(Name = "Materie")]
        public int? MaterieId { get; set; }
        public virtual RawMaterials Materii { get; set; }

        [Display(Name = "Cantitate")]
        public int Cantitate { get; set; }

        [Display(Name = "User")]
        public int? UserId { get; set; }        

        [Display(Name = "Modificat de")]
        public int? UpdatedBy { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
