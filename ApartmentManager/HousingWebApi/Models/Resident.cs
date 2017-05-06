namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Resident
    {
        [Key]
        public int ResidentNr { get; set; }

        public int ApartmentNr { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public int? Phone { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
