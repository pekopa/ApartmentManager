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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PictureId { get; set; }

        public int DefectId { get; set; }

        public string Picture { get; set; }

        public virtual Defect Defect { get; set; }
    }
}
