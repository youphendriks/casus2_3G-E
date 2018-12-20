namespace Summ2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCard")]
    public partial class tblCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCard()
        {
            tblCategories = new HashSet<tblCategory>();
            tblDecks = new HashSet<tblDeck>();
        }

        [Key]
        public int CardID { get; set; }

        public string Name { get; set; }

        [StringLength(50)]
        public string Owned { get; set; }

        public string State { get; set; }

        [StringLength(50)]
        public string Foil { get; set; }

        public string Language { get; set; }

        public int? BuyPrice { get; set; }

        public int? CurrentPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCategory> tblCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDeck> tblDecks { get; set; }
    }
}
