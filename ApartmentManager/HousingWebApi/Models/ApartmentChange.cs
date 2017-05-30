namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApartmentChange")]
    public partial class ApartmentChange
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApartmentChange()
        {
            ChangeComments = new HashSet<ChangeComment>();
            ChangeDocuments = new HashSet<ChangeDocument>();
        }

        [Key]
        public int ChangeId { get; set; }

        public int ApartmentId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UploadDate { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Apartment Apartment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeComment> ChangeComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChangeDocument> ChangeDocuments { get; set; }
    }
}
