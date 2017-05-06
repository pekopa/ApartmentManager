namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApartmentNr { get; set; }

        [Required]
        [StringLength(15)]
        public string Username { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [Required]
        [StringLength(1)]
        public string Type { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        [StringLength(20)]
        public string SecondName { get; set; }

        [StringLength(20)]
        public string SecondLastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SecondBirthDate { get; set; }

        [StringLength(12)]
        public string SecondPhone { get; set; }

        [StringLength(30)]
        public string SecondEmail { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
