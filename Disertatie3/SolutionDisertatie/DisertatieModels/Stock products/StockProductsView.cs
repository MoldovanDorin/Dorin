using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Model
{
    class StockProductsView
    {
        public int Id { get; set; }

        [Display(Name = "Data")]
        public DateTime Data { get; set; }
    }
}
