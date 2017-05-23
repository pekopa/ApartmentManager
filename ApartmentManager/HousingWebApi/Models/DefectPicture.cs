namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DefectPicture")]
    public partial class DefectPicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PictureId { get; set; }

        public int DefectId { get; set; }

        [StringLength(50)]
        public string Picture { get; set; }

        public virtual Defect Defect { get; set; }
    }
}
