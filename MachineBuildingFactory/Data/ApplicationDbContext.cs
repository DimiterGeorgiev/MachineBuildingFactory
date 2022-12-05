using MachineBuildingFactory.Data.Models;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<ApplicationUserWorkingAssembly> ApplicationUserWorkingAssemblies { get; set; } = null!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;

        public DbSet<Material> Materials { get; set; } = null!;

        public DbSet<ProductionPart> ProductionParts { get; set; } = null!;

        public DbSet<PurchasedPart> PurchasedParts { get; set; } = null!;

        public DbSet<Supplier> Suppliers { get; set; } = null!;

        public DbSet<TypeOfProductionPart> TypeOfProductionParts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);




            builder.Entity<ApplicationUserAssembly>()
                .HasKey(x => new { x.ApplicationUserId, x.AssemblyId });

            builder.Entity<ApplicationUserWorkingAssembly>()
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
                   Image = "https://files.fm/thumb_show.php?i=wuvwwvyyu",
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
                   Image = "https://files.fm/thumb_show.php?i=yanftmubg",
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
               },
               new ProductionPart()
               {
                   Id = 7,
                   Name = "Base plate",
                   Description = "For all type of construction",
                   Image = "https://files.fm/thumb_show.php?i=avqbb8jgk",
                   TypeOfProductionPartId = 2,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "DD",
                   SurfaceArea = 5.3,
                   DrawingNumber = "BP-080-008",
                   Weight = 12.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)3,
                   TypeOfPaint = (Enums.TypeOfPaint?)2,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)3,
                   LaserCutLength = 8.9,
                   MaterialId = 5
               },
               new ProductionPart()
               {
                   Id = 8,
                   Name = "Gear 34/69",
                   Description = "Gear for gearbox",
                   Image = "https://files.fm/thumb_show.php?i=n62awsh2s",
                   TypeOfProductionPartId = 1,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "TT",
                   SurfaceArea = 8.3,
                   DrawingNumber = "GB-200-036",
                   Weight = 6.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)3,
                   TypeOfPaint = (Enums.TypeOfPaint?)1,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
                   LaserCutLength = 0,
                   MaterialId = 4
               },
               new ProductionPart()
               {
                   Id = 9,
                   Name = "Brackets",
                   Description = "Brackets for Frame",
                   Image = "https://files.fm/thumb_show.php?i=qjugekfuf",
                   TypeOfProductionPartId = 2,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "TT",
                   SurfaceArea = 8.3,
                   DrawingNumber = "GB-200-036",
                   Weight = 6.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)3,
                   TypeOfPaint = (Enums.TypeOfPaint?)1,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
                   LaserCutLength = 0,
                   MaterialId = 1
               },
               new ProductionPart()
               {
                   Id = 10,
                   Name = "Frame 1000x200",
                   Description = "Frame big size",
                   Image = "https://files.fm/thumb_show.php?i=2y4zzx6pb",
                   TypeOfProductionPartId = 3,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "GG",
                   SurfaceArea = 105.3,
                   DrawingNumber = "FBS-2365-078",
                   Weight = 6.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)3,
                   TypeOfPaint = (Enums.TypeOfPaint?)1,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
                   LaserCutLength = 0,
                   MaterialId = 1
               },
               new ProductionPart()
               {
                   Id = 11,
                   Name = "Rack-Wheel",
                   Description = "Toot 45, M=7, TRE-89",
                   Image = "https://files.fm/thumb_show.php?i=8a2t5t9z9",
                   TypeOfProductionPartId = 1,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "GG",
                   SurfaceArea = 1.2,
                   DrawingNumber = "RW-859-026",
                   Weight = 5.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)1,
                   TypeOfPaint = (Enums.TypeOfPaint?)1,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
                   LaserCutLength = 0,
                   MaterialId = 1
               },
               new ProductionPart()
               {
                   Id = 12,
                   Name = "Sprocket",
                   Description = "Toot 65, M=4, SPG-05",
                   Image = "https://files.fm/thumb_show.php?i=2gqgfmt48",
                   TypeOfProductionPartId = 1,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "GG",
                   SurfaceArea = 1.2,
                   DrawingNumber = "RW-859-026",
                   Weight = 5.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)1,
                   TypeOfPaint = (Enums.TypeOfPaint?)1,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
                   LaserCutLength = 0,
                   MaterialId = 1
               },
               new ProductionPart()
               {
                   Id = 13,
                   Name = "Just Details",
                   Description = "Thsi Part breaks the DetailView",
                   Image = "https://files.fm/thumb_show.php?i=wzjth76ag",
                   TypeOfProductionPartId = 2,
                   CreatedOn = DateTime.Now,
                   AuthorSignature = "DD",
                   SurfaceArea = 1.2,
                   DrawingNumber = "BV-000-001",
                   Weight = 5.6,
                   SurfaceTreatment = (Enums.TypeOfSurfaceTreatment?)1,
                   TypeOfPaint = (Enums.TypeOfPaint?)1,
                   ColorOfPaintRal = (Enums.ColorOfPaintRal?)1,
                   LaserCutLength = 0,
                   MaterialId = 1
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
              Name = "Mechanically processed"
          },
          new TypeOfProductionPart()
          {
              Id = 2,
              Name = "Sheet metal"
          },
          new TypeOfProductionPart()
          {
              Id = 3,
              Name = "Weld construction"
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

            builder
                .Entity<Assembly>()
                .HasData(
                new Assembly()
                {
                    Id = 3,
                    Name = "Weld construction",
                    DrawingNumber = "CW-001-00",
                    Description = "Base support for hole construction",
                    Image = "https://files.fm/thumb_show.php?i=e3en9mxbj",
                    AuthorSignature = "GG",
                    CreatedOn = DateTime.Now
                },
                new Assembly()
                {
                    Id = 4,
                    Name = "Rotational casting machine",
                    DrawingNumber = "CF-050-00",
                    Description = "Rotational casting is the best way to make hollow resin parts",
                    Image = "https://files.fm/thumb_show.php?i=rcgp3g9nf",
                    AuthorSignature = "PP",
                    CreatedOn = DateTime.Now
                },
                new Assembly()
                {
                    Id = 5,
                    Name = "Steam turbine",
                    DrawingNumber = "WM-026-100-R",
                    Description = "Steam turbine 100 kW",
                    Image = "https://files.fm/thumb_show.php?i=rafszmvtu",
                    AuthorSignature = "DD",
                    CreatedOn = DateTime.Now
                },
                new Assembly()
                {
                    Id = 6,
                    Name = "Cooling system",
                    DrawingNumber = "CS-125-TF58-000",
                    Description = "Cooling system for industry",
                    Image = "https://files.fm/thumb_show.php?i=zqg8235n3",
                    AuthorSignature = "DD",
                    CreatedOn = DateTime.Now
                },
                new Assembly()
                {
                    Id = 7,
                    Name = "Compressor",
                    DrawingNumber = "CM-300-RF98-700",
                    Description = "High pressure reciprocating compressor",
                    Image = "https://files.fm/thumb_show.php?i=8ug7rbkqh",
                    AuthorSignature = "TT",
                    CreatedOn = DateTime.Now
                }
                );


            builder
                .Entity<Manufacturer>()
                .HasData(new Manufacturer()
                {
                    Id = 5,
                    Name = "Festo",
                    Email = "office@festo.com",
                    UrlAddress = "Festo.com"

                },
                new Manufacturer
                {
                    Id = 6,
                    Name = "SEW",
                    Email = "office@sew.com",
                    UrlAddress = "Sew.com"
                },
                new Manufacturer
                {
                    Id = 7,
                    Name = "Siemens",
                    Email = "office@siemens.com",
                    UrlAddress = "SEW.com"
                },
                new Manufacturer
                {
                    Id = 8,
                    Name = "Valeo",
                    Email = "office@valeo.com",
                    UrlAddress = "Valeo.com"
                });

            builder.Entity<Supplier>()
                .HasData(
                new Supplier
                {
                    Id = 11,
                    Name = "Norelem",
                    Email = "office@norelem.com",
                    UrlAddress = "Norelem.com"
                },
                new Supplier
                {
                    Id = 12,
                    Name = "Misumi",
                    Email = "office@misumi.com",
                    UrlAddress = "Misumi.com"
                },
                new Supplier
                {
                    Id = 13,
                    Name = "Maedler",
                    Email = "office@maedler.com",
                    UrlAddress = "Maedler.com"
                },
                new Supplier
                {
                    Id = 14,
                    Name = "Haberkorn",
                    Email = "office@haberkorn.com",
                    UrlAddress = "Haberkorn.com"
                });


            builder.Entity<PurchasedPart>()
                .HasData(
                new PurchasedPart
                {
                    Id = 5,
                    Name = "Gearbox",
                    ItemNumber = "GM-100/25-368A",
                    SupplierId = 12,
                    ManufacturerId = 5,
                    Description = "Gear motor of SEW, Supplier: Misumi",
                    Image = "https://files.fm/thumb_show.php?i=zbkja84dh",
                    Weight = 56.8,
                    Standard = "ISO 36264"
                },
                new PurchasedPart
                {
                    Id = 6,
                    Name = "Compact cylinders ADN-S",
                    ItemNumber = "ADN-S-12-25-I-P",
                    SupplierId = 14,
                    ManufacturerId = 6,
                    Description = "Compact cylinders ADN-S, double-acting",
                    Image = "https://files.fm/thumb_show.php?i=bduy24ra6",
                    Weight = 2.3,
                    Standard = "ISO 21287"
                },
                new PurchasedPart
                {
                    Id = 7,
                    Name = "Pillow block bearing",
                    ItemNumber = "SKF SY 35 TR",
                    SupplierId = 13,
                    ManufacturerId = 7,
                    Description = "For material handling applications",
                    Image = "https://files.fm/thumb_show.php?i=a62t5h3r2",
                    Weight = 1.3,
                    Standard = "ISO 55629"
                },
                 new PurchasedPart
                 {
                     Id = 8,
                     Name = "Variable speed drive",
                     ItemNumber = "ATV310",
                     SupplierId = 11,
                     ManufacturerId = 7,
                     Description = "Read holding registers (03) 29 words",
                     Image = "https://files.fm/thumb_show.php?i=sh76p8cgu",
                     Weight = 1.3,
                     Standard = "ISO 32685"
                 },
                 new PurchasedPart
                 {
                     Id = 9,
                     Name = "Linear Bearing",
                     ItemNumber = "LMF 06UU",
                     SupplierId = 13,
                     ManufacturerId = 7,
                     Description = "Linear Bearing with Round Flange",
                     Image = "https://files.fm/thumb_show.php?i=thrgt2tfr",
                     Weight = 1.3,
                     Standard = "ISO 36958"
                 }
                );


        }

        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = "a719be14-6ee5-4a10-a1b6-382fc43c4d0b",
                FirstName = "Peter",
                LastName = "Petrov",
                Title = Enums.Title.DI,
                Phone = "+3596598665",
                Department = Enums.Department.Management,
                Signature = "PP",
                UserName = "peter",
                NormalizedUserName = "PETER",
                Email = "peter@abv.bg",
                NormalizedEmail = "PETER@ABV.BG",
                LockoutEnabled = true,
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            user.PasswordHash = passwordHasher.HashPassword(user, "123aA!");

            builder.Entity<ApplicationUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "236787a2-4edc-492e-acb2-5f4a00ade9e3", Name = "Management", ConcurrencyStamp = "1", NormalizedName = "Management" },
            new IdentityRole() { Id = "cadc8910-5d74-4791-aad9-3523e2fd2468", Name = "IT", ConcurrencyStamp = "2", NormalizedName = "IT" }
            );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { RoleId = "236787a2-4edc-492e-acb2-5f4a00ade9e3", UserId = "a719be14-6ee5-4a10-a1b6-382fc43c4d0b" }
            );
        }

    }

}
