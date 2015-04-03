using DisertatieModels.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisertatieModels.Models
{
    public class StockMaterials
    {
        [Required]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public virtual List<AmountOfMaterial> Materials { get; set; }

    

    }
}