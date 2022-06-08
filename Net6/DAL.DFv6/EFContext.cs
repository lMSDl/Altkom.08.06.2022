using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.DFv6
{
    public partial class EFContext : DbContext
    {
        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=EF;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Street).IsRequired();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasMany(d => d.Addresses)
                    .WithMany(p => p.People)
                    .UsingEntity<Dictionary<string, object>>(
                        "PeopleAddress",
                        l => l.HasOne<Address>().WithMany().HasForeignKey("AddressId"),
                        r => r.HasOne<Person>().WithMany().HasForeignKey("PersonId"),
                        j =>
                        {
                            j.HasKey("PersonId", "AddressId");

                            j.ToTable("PeopleAddresses");

                            j.HasIndex(new[] { "AddressId" }, "IX_PeopleAddresses_AddressId");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
