using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace seminarskiBooks.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Knjiga> Knjigas { get; set; } = null!;
        public virtual DbSet<Zanr> Zanrs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.Idautor)
                    .HasName("PK__Autor__5DC53A137268ED55");

                entity.ToTable("Autor");

                entity.Property(e => e.Idautor)
                    .ValueGeneratedNever()
                    .HasColumnName("IDAutor");

                entity.Property(e => e.ImeAuotra).HasMaxLength(50);

                entity.Property(e => e.PrezimeAuotra).HasMaxLength(50);
            });

            modelBuilder.Entity<Knjiga>(entity =>
            {
                entity.HasKey(e => e.Idknjiga)
                    .HasName("PK__Knjiga__9C73C0725BC513E9");

                entity.ToTable("Knjiga");

                entity.Property(e => e.Idknjiga)
                    .ValueGeneratedNever()
                    .HasColumnName("IDKnjiga");

                entity.Property(e => e.DatumIzdavanja).HasColumnType("date");

                entity.Property(e => e.Idautor).HasColumnName("IDAutor");

                entity.Property(e => e.Idzanr).HasColumnName("IDZanr");

                entity.Property(e => e.IzdavackaKuca).HasMaxLength(50);

                entity.Property(e => e.NazivKnjige).HasMaxLength(50);

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Knjigas)
                    .HasForeignKey(d => d.Idautor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Knjiga__IDAutor__16644E42");

                entity.HasOne(d => d.IdzanrNavigation)
                    .WithMany(p => p.Knjigas)
                    .HasForeignKey(d => d.Idzanr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Knjiga__IDZanr__1758727B");
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.HasKey(e => e.Idzanr)
                    .HasName("PK__Zanr__6B452FCDF0C44CFA");

                entity.ToTable("Zanr");

                entity.Property(e => e.Idzanr)
                    .ValueGeneratedNever()
                    .HasColumnName("IDZanr");

                entity.Property(e => e.NazivZanra).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
