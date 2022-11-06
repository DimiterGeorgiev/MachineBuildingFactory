using MachineBuildingFactory.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MachineBuildingFactory.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Assembly> Assemblies { get; set; } = null!;

        public DbSet<AssemblyProductionPart> AssemblyProductionParts { get; set; } = null!;

        public DbSet<AssemblyPurchasedPart> AssemblyPurchasedParts { get; set; } = null!;

        public DbSet<ApplicationUserAssembly> ApplicationUserAssemblies { get; set; } = null!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;

        public DbSet<Material> Materials { get; set; } = null!;

        public DbSet<ProductionPart> ProductionParts { get; set; } = null!;

        public DbSet<PurchasedPart> PurchasedParts { get; set; } = null!;

        public DbSet<Supplier> Suppliers { get; set; } = null!;

        public DbSet<TypeOfProductionPart> TypeOfProductionParts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserAssembly>()
                .HasKey(x => new { x.ApplicationUserId, x.AssemblyId });

            builder.Entity<AssemblyProductionPart>()
                .HasKey(x => new { x.AssemblyId, x.ProductionPartId });

            builder.Entity<AssemblyPurchasedPart>()
                .HasKey(x => new { x.AssemblyId, x.PurchasedPartId });

            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();


            builder
               .Entity<ProductionPart>()
               .HasData(new ProductionPart()
               {
                   Id = 5,
                   Name = "Consol",
                   Description = "This is just a probe part.",
                   Image = "Picture",
                   TypeOfProductionPartId = 1,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "PP",
                   SurfaceArea = 2.3,
                   DrawingNumber = "CL-025-001",
                   Weight = 5.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)1,
                   TypeOfPaint = (Enums.TypeOfPaint?)2,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)3,
                   LaserCutLength = 4.3,
                   MaterialId = 2
               },
               new ProductionPart()
               {
                   Id = 6,
                   Name = "Shaft",
                   Description = "Shaft for all target.",
                   Image = "Picture",
                   TypeOfProductionPartId = 2,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "TT",
                   SurfaceArea = 1.3,
                   DrawingNumber = "CL-025-002",
                   Weight = 8.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)2,
                   TypeOfPaint = (Enums.TypeOfPaint?)3,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
                   LaserCutLength = 5.9,
                   MaterialId = 3
               }

               );


            builder
                .Entity<Material>()
          .HasData(new Material()
          {
              Id = 1,
              MaterialNumber = "1.0038"
          },
          new Material()
          {
              Id = 2,
              MaterialNumber = "1.8714"
          },
          new Material()
          {
              Id = 3,
              MaterialNumber = "1.5786"
          },
          new Material()
          {
              Id = 4,
              MaterialNumber = "1.4302"
          },
          new Material()
          {
              Id = 5,
              MaterialNumber = "1.7025"
          });




            builder
                .Entity<TypeOfProductionPart>()
          .HasData(new TypeOfProductionPart()
          {
              Id = 1,
              Name = "MechanicallyProcessed"
          },
          new TypeOfProductionPart()
          {
              Id = 2,
              Name = "Sheetmetal"
          },
          new TypeOfProductionPart()
          {
              Id = 3,
              Name = "Weldconstruction"
          },
          new TypeOfProductionPart()
          {
              Id = 4,
              Name = "Lasercut"
          },
          new TypeOfProductionPart()
          {
              Id = 5,
              Name = "Cast"
          });



        }
    }
}