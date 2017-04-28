namespace HousingWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Residents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResidentNumber { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        public int? Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(26)]
        public string Email { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public int ApartmentNr { get; set; }

        [StringLength(20)]
        public string SecondName { get; set; }

        [StringLength(20)]
        public string SecondLastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SecondBirthDate { get; set; }

        public int? SecondPhone { get; set; }

        [StringLength(25)]
        public string SecondEmail { get; set; }

        [StringLength(12)]
        public string Username { get; set; }

        [StringLength(14)]
        public string Password { get; set; }

        public virtual Apartments Apartments { get; set; }
    }
}
