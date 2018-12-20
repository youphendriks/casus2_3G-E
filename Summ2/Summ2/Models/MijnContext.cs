namespace Summ2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MijnContext : DbContext
    {
        public MijnContext()
            : base("name=MijnContext")
        {
        }

        public virtual DbSet<tblCard> tblCards { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblDeck> tblDecks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCard>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tblCard>()
                .Property(e => e.Owned)
                .IsUnicode(false);

            modelBuilder.Entity<tblCard>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<tblCard>()
                .HasMany(e => e.tblCategories)
                .WithMany(e => e.tblCards)
                .Map(m => m.ToTable("tblCardCategory").MapLeftKey("CardID").MapRightKey("CategoryID"));

            modelBuilder.Entity<tblCard>()
                .HasMany(e => e.tblDecks)
                .WithMany(e => e.tblCards)
                .Map(m => m.ToTable("tblCardDeck").MapLeftKey("CardID").MapRightKey("DeckID"));

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<tblDeck>()
                .Property(e => e.DeckName)
                .IsUnicode(false);
        }
    }
}
