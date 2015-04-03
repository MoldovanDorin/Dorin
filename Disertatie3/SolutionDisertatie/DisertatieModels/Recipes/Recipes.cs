using DisertatieModels.Model;
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

        public string Nume { get; set; }        

        public int? UserId { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public virtual List<RecipesMaterials> RawMaterials { get; set; }
        public virtual List<AmountOfProducts> Stocks { get; set; }
        
    }
}