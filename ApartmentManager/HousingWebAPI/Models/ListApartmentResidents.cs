namespace HousingWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ListApartmentResidents : DbContext
    {
        public ListApartmentResidents()
            : base("name=ListApartmentResidents")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<ApartmentResident> ApartmentResidents { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartmentResident>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentResident>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentResident>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
