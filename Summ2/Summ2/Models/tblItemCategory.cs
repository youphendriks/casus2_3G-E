namespace Summ2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblItemCategory")]
    public partial class tblItemCategory
    {
        [Key]
        public int ItemCategoryID { get; set; }

        public int ItemID { get; set; }

        public int CategoryID { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblItem tblItem { get; set; }
    }
}
