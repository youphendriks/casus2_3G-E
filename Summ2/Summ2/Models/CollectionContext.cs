namespace Summ2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CollectionContext : DbContext
    {
        public CollectionContext()
            : base("name=CollectionContext")
        {
        }

        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCollection> tblCollections { get; set; }
        public virtual DbSet<tblItem> tblItems { get; set; }
        public virtual DbSet<tblItemCategory> tblItemCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCategory>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.CategoryBeschrijving)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollection>()
                .Property(e => e.CollectionName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCollection>()
                .HasMany(e => e.tblItems)
                .WithOptional(e => e.tblCollection)
                .HasForeignKey(e => e.ColletionID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<tblItem>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<tblItem>()
                .Property(e => e.ItemBeschrijving)
                .IsUnicode(false);

            modelBuilder.Entity<tblItem>()
                .Property(e => e.ItemOwned)
                .IsUnicode(false);

            modelBuilder.Entity<tblItem>()
                .Property(e => e.ItemState)
                .IsUnicode(false);
        }
    }
}
