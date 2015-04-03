using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using DisertatieModels.Models;
using DisertatieModels.Model;

namespace DisertatieEntity
{
    public class DbEntities : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Consumption> Consumption { get; set; }
        public DbSet<RawMaterials> RawMaterials { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<StockMaterials> StockMaterials { get; set; }
        public DbSet<StockProducts> StocProduse { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Collections> Collections { get; set; }


        public DbEntities()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //modelBuilder.Entity<RawMaterials>()
            // .HasMany(c => c.Stock).WithMany(i => i.Materials)
            // .Map(t => t.MapLeftKey("Id")
            //     .MapRightKey("Id")
            //     .ToTable("AmountOfMaterial"));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AmountOfMaterial> AmountOfMaterials { get; set; }

        public DbSet<AmountOfProducts> AmountOfProducts { get; set; }

        public DbSet<RecipesMaterials> RecipesMaterials { get; set; }
    }
}
