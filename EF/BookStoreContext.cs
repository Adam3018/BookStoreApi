using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookStoreApi.EF
{
    public partial class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Knjiga> Knjigas { get; set; }
        public virtual DbSet<Zanr> Zanrs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=BookStoreDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.AutorId).HasColumnName("AutorID");

                entity.Property(e => e.ImeAutora)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrezimeAutora)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Knjiga>(entity =>
            {
                entity.ToTable("Knjiga");

                entity.Property(e => e.KnjigaId).HasColumnName("KnjigaID");

                entity.Property(e => e.AutorId).HasColumnName("AutorID");

                entity.Property(e => e.NazivKnjige)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZanrId).HasColumnName("ZanrID");

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Knjigas)
                    .HasForeignKey(d => d.AutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Knjiga_Autor");

                entity.HasOne(d => d.Zanr)
                    .WithMany(p => p.Knjigas)
                    .HasForeignKey(d => d.ZanrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Knjiga_Zanr");
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.ToTable("Zanr");

                entity.Property(e => e.ZanrId).HasColumnName("ZanrID");

                entity.Property(e => e.ZanrNaziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
