namespace Summ2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCollection")]
    public partial class tblCollection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCollection()
        {
            tblItems = new HashSet<tblItem>();
        }

        [Key]
        public int CollectionID { get; set; }

        public string CollectionName { get; set; }

        public string CollectionDiscription { get; set; }

        public string Status { get; set; }

        public string StatusBeschrijving { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItem> tblItems { get; set; }
    }
}
