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
        public virtual DbSet<ApartmentChange> ApartmentChanges { get; set; }
        public virtual DbSet<ChangeComment> ChangeComments { get; set; }
        public virtual DbSet<ChangeDocument> ChangeDocuments { get; set; }
        public virtual DbSet<Defect> Defects { get; set; }
        public virtual DbSet<DefectComment> DefectComments { get; set; }
        public virtual DbSet<DefectPicture> DefectPictures { get; set; }
        public virtual DbSet<PastUser> PastUsers { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AllResident> AllResidents { get; set; }
        public virtual DbSet<ApartmentResident> ApartmentResidents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.ApartmentChanges)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Defects)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.PastUsers)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Residents)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApartmentChange>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentChange>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentChange>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentChange>()
                .HasMany(e => e.ChangeComments)
                .WithRequired(e => e.ApartmentChange)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApartmentChange>()
                .HasMany(e => e.ChangeDocuments)
                .WithRequired(e => e.ApartmentChange)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChangeComment>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Defect>()
                .HasMany(e => e.DefectComments)
                .WithRequired(e => e.Defect)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Defect>()
                .HasMany(e => e.DefectPictures)
                .WithRequired(e => e.Defect)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DefectComment>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<PastUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<PastUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<PastUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<PastUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<PastUser>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<PastUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Resident>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Resident>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Resident>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Resident>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<AllResident>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentResident>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentResident>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentResident>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
