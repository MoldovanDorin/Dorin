using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Model
{
    class AmountOfProductView
    {
        public int Id { get; set; }

        [Display(Name = "Produs")]
        public int RecipesId { get; set; }
        public virtual Recipes recipes { get; set; }

        [Display(Name = "Stoc")]
        public int StockProductsId { get; set; }
        public virtual StockProducts stockProducts { get; set; }

        [Display(Name = "Cantitate")]
        public int Cantitate { get; set; }
    }
}
