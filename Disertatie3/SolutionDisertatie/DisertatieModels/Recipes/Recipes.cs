using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisertatieModels.Models
{
    public class Recipes
    {
        [Required]
        public int Id { get; set; }

        public int? ProdusId { get; set; }

        public virtual Product Produse { get; set; }

        public int? MaterieId { get; set; }

        public virtual RawMaterials Materii { get; set; }

        public int Cantitate { get; set; }

        public int? UserId { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual UserProfile UserProfile { get; set; }
                
        
        
    }
}