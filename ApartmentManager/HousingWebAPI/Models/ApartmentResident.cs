namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApartmentResident
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApartmentNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public int? PhoneNo { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }
    }
}
