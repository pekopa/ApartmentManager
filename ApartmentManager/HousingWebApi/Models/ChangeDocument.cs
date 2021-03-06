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
        public int DocumentId { get; set; }

        public int ChangeId { get; set; }

        [StringLength(50)]
        public string Document { get; set; }

        public virtual Change Change { get; set; }
    }
}
