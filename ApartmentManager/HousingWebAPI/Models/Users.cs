namespace HousingWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
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

        public virtual Apartments Apartments { get; set; }
    }
}
