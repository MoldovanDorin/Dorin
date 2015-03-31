using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Models
{
    class StockProductsView
    {
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Produs")]
        public int? ProdusId { get; set; }
        public virtual Product Produse { get; set; }

        [Display(Name = "Cantitate")]
        public int Cantitate { get; set; }
    }
}
