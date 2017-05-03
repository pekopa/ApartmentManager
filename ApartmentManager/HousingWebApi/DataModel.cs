namespace HousingWebApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Defect> Defects { get; set; }
        public virtual DbSet<PastContractOwner> PastContractOwners { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .Property(e => e.Size)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Apartment>()
                .Property(e => e.MonthlyCharge)
                .IsFixedLength();

            modelBuilder.Entity<Apartment>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Defects)
                .WithRequired(e => e.Apartment)
                .HasForeignKey(e => e.ApartmentNr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Residents)
                .WithRequired(e => e.Apartment)
                .HasForeignKey(e => e.ApartmentNr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.Apartment);

            modelBuilder.Entity<Defect>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Defect>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<PastContractOwner>()
                .Property(e => e.ApartmentNr)
                .IsFixedLength();

            modelBuilder.Entity<Resident>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<Resident>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Resident>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.SecondName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.SecondLastName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.SecondEmail)
                .IsFixedLength();
        }
    }
}
