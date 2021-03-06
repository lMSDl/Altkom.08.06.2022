using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Server=(local);Database=EF;Integrated Security=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("People")
                .HasMany(x => x.Addresses)
                .WithMany(x => x.People)
                .UsingEntity<Dictionary<string, object>>(
                "PeopleAddresses",
                p => p.HasOne<Address>().WithMany().HasForeignKey("AddressId"),
                p => p.HasOne<Person>().WithMany().HasForeignKey("PersonId"),
                x =>
                {
                    x.HasKey("PersonId", "AddressId");
                    x.ToTable("PeopleAddresses");
                });


            modelBuilder.Entity<Product>()
                .ToTable("Products", x => x.IsTemporal(y =>
                {
                    y.HasPeriodStart("From");
                    y.HasPeriodEnd("To");
                    y.UseHistoryTable("ProductsData");
                }));

            foreach (var item in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.PropertyInfo?.PropertyType == typeof(DateTime)))
            {
                item.SetColumnType("dateTime");
            }
            

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<float>()
                .HavePrecision(10);

        }
    }
}
