using AspDotNetCoreWebApi.Core.Entity;
using AspDotNetCoreWebApi.Data.Configuration;
using AspDotNetCoreWebApi.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreWebApi.Data
{
    public class AppDbContext : DbContext // SQLServer tarafına karşılık geliyor. Yani tablolar
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // DB de tablolar oluşmadan çalışacak metot
        {
            // Oluşacak tabloların hangi kolonları bu kolonların tipleri ne olacak onun yapıldığı yer

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}
