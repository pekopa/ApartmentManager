namespace HousingWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApartmentsDataContext : DbContext
    {
        public ApartmentsDataContext()
            : base("name=ApartmentsDataContext")
        {
        }

        public virtual DbSet<Apartments> Apartments { get; set; }
        public virtual DbSet<Defects> Defects { get; set; }
        public virtual DbSet<PastContractOwners> PastContractOwners { get; set; }
        public virtual DbSet<Residents> Residents { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartments>()
                .Property(e => e.Size)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Apartments>()
                .Property(e => e.MonthlyCharge)
                .IsFixedLength();

            modelBuilder.Entity<Apartments>()
                .HasMany(e => e.Defects)
                .WithRequired(e => e.Apartments)
                .HasForeignKey(e => e.ApartmentNr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartments>()
                .HasMany(e => e.Residents)
                .WithRequired(e => e.Apartments)
                .HasForeignKey(e => e.ApartmentNr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartments>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Apartments)
                .HasForeignKey(e => e.ApartmentNr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Defects>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Defects>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Defects>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Defects>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<PastContractOwners>()
                .Property(e => e.ApartmentNr)
                .IsFixedLength();

            modelBuilder.Entity<Residents>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Residents>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Residents>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Residents>()
                .Property(e => e.SecondName)
                .IsFixedLength();

            modelBuilder.Entity<Residents>()
                .Property(e => e.SecondLastName)
                .IsFixedLength();

            modelBuilder.Entity<Residents>()
                .Property(e => e.SecondEmail)
                .IsFixedLength();

            modelBuilder.Entity<Residents>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Residents>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsFixedLength();
        }
    }
}
