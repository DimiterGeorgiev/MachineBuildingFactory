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



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserAssembly>()
                .HasKey(x => new {x.ApplicationUserId, x.AssemblyId });

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

        }
    }
}