using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Model
{
    class RecipesMaterialsView
    {
        public int Id { get; set; }

        [Display(Name = "Reteta")]
        public int RecipesId { get; set; }
        public virtual Recipes Recipes { get; set; }

        [Display(Name = "Materie prima")]
        public int RawMaterialsId { get; set; }
        public virtual RawMaterials RawMaterials { get; set; }

        [Display(Name = "Cantitate")]
        public int Cantitate { get; set; }
    }
}
