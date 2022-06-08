using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.DFv5
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
        public virtual DbSet<PeopleAddress> PeopleAddresses { get; set; }
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
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Street).IsRequired();
            });

            modelBuilder.Entity<PeopleAddress>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.AddressId });

                entity.HasIndex(e => e.AddressId, "IX_PeopleAddresses_AddressId");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PeopleAddresses)
                    .HasForeignKey(d => d.AddressId);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PeopleAddresses)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
