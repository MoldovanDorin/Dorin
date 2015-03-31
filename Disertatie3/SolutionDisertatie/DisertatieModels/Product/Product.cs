using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisertatieModels.Models
{
    public class Product
    {
        public virtual ICollection<Recipes> Retete { get; set; }
        public virtual ICollection<StockProducts> StocProduse { get; set; }

        [Required]
        public int Id { get; set; }

        public string Nume { get; set; }

        public bool IsDeleted { get; set; }

        [Display(Name = "Adaugat de ")]
        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}