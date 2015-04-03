using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Model
{
    public class AmountOfProducts
    {
        [Required]
        public int Id { get; set; }
        public int RecipesId { get; set; }
        public virtual Recipes recipes { get; set; }
        public int StockProductsId { get; set; }
        public virtual StockProducts stockProducts { get; set; }
        public int Cantitate { get; set; }
    }
}
