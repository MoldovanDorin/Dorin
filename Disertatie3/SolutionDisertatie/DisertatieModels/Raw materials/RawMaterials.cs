using DisertatieModels.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisertatieModels.Models
{
    public class RawMaterials
    {
        //public virtual ICollection<StockMaterials> StocMaterii { get; set; }
        //public virtual ICollection<Consumption> Consum { get; set; }
        //public virtual ICollection<Recipes> Retete { get; set; }

        [Required]
        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }

        [Display(Name = "Adaugat de ")]
        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public bool IsDeleted { get; set; }

        public virtual List<RecipesMaterials> Recipes { get; set; }
        public virtual List<AmountOfMaterial> Stock { get; set; }
    }
}