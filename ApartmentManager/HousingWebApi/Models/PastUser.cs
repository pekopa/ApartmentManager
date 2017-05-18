namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PastUser")]
    public partial class PastUser
    {
        [Key]
        [StringLength(30)]
        public string Username { get; set; }

        public int ApartmentId { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        public bool IsBm { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public byte[] Picture { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MoveInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MoveOutDate { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
