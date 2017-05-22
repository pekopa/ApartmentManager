namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChangeComment")]
    public partial class ChangeComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommentId { get; set; }

        public int ChangeId { get; set; }

        public string Comment { get; set; }

        public virtual ApartmentChange ApartmentChange { get; set; }
    }
}
