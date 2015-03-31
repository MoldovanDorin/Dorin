using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Models
{
    class StockMaterialsView
    {
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Materie")]
        public int? MaterieId { get; set; }
        public virtual RawMaterials Materii { get; set; }

        [Display(Name = "Cantitate")]
        public int Cantitate { get; set; }
    }
}
