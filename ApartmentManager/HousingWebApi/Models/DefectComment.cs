namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DefectComment")]
    public partial class DefectComment
    {
        [Key]
        public int CommentId { get; set; }

        public int DefectId { get; set; }

        public string Comment { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public virtual Defect Defect { get; set; }
    }
}
