using DisertatieModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertatieModels.Model
{
    class RecipesView
    {
        public int Id { get; set; }

        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Display(Name = "Adaugat de userul")]
        public int? UserId { get; set; }

        [Display(Name = "Actualizat de userul")]
        public int? UpdatedBy { get; set; }
        public virtual UserProfile UserProfile { get; set; }

    }
}
