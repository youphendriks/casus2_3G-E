namespace Summ2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblItem")]
    public partial class tblItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblItem()
        {
            tblItemCategories = new HashSet<tblItemCategory>();
        }

        [Key]
        public int ItemID { get; set; }

        public int? ColletionID { get; set; }

        public string ItemName { get; set; }

        public string ItemBeschrijving { get; set; }

        public string ItemOwned { get; set; }

        public string ItemState { get; set; }

        public int? BuyPrice { get; set; }

        public int? CurrentPrice { get; set; }

        public int? PriceDifference { get; set; }

        public virtual tblCollection tblCollection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemCategory> tblItemCategories { get; set; }
    }
}
