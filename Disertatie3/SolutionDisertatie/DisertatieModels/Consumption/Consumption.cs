﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DisertatieModels.Models
{
    public class Consumption
    {
        [Required]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int? MaterieId { get; set; }
        public virtual RawMaterials Materii { get; set; }

        public int? UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public int Cantitate { get; set; }
    }
}