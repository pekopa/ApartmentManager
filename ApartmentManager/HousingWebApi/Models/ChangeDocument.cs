namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChangeDocument")]
    public partial class ChangeDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DocumentId { get; set; }

        public int ChangeId { get; set; }

        [StringLength(50)]
        public string Document { get; set; }

        public virtual ApartmentChange ApartmentChange { get; set; }
    }
}
