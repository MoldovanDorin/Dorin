using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Model
{
    class AmountOfMaterialView
    {
        public int Id { get; set; }

        [Display(Name = "Materie prima")]
        public int RawMaterialsId { get; set; }
        public virtual RawMaterials rawMaterials { get; set; }

        [Display(Name = "Stoc")]
        public int StockMaterialsId { get; set; }
        public virtual StockMaterials stockMaterials { get; set; }

        [Display(Name = "Cantitate")]
        public int Cantitate { get; set; }
    }
}
