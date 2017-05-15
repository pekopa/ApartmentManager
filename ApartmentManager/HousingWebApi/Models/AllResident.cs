namespace HousingWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AllResident
    {
        [Key]
        [StringLength(20)]
        public string FirstName { get; set; }
    }
}
