namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Defect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DefectNumber { get; set; }

        public int ApartmentNr { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateUploaded { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Picture { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture3 { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
