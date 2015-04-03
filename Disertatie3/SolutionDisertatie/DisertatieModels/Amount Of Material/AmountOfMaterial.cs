using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Model
{
    public class AmountOfMaterial
    {
        [Required]
        public int Id { get; set; }
        public int RawMaterialsId { get; set; }
        public virtual RawMaterials rawMaterials { get; set; }
        public int StockMaterialsId { get; set; }
        public virtual StockMaterials stockMaterials { get; set; }
        public int Cantitate { get; set; }
    }
}
