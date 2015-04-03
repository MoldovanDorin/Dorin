using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Models
{
    public class RecipesMaterials
    {
        [Required]
        public int Id { get; set; }
        public int RecipesId { get; set; }
        public virtual Recipes Recipes { get; set; }
        public int RawMaterialsId { get; set; }
        public virtual RawMaterials RawMaterials { get; set; }
        public int Cantitate { get; set; }
    }
}
