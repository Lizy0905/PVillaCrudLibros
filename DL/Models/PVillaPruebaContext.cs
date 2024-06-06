using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL.Models
{
    public partial class PVillaPruebaContext : DbContext
    {
        public PVillaPruebaContext()
        {
        }

        public PVillaPruebaContext(DbContextOptions<PVillaPruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Libro> Libros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=PVillaPrueba;Trusted_Connection=True; password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__Libro__3E0B49AD9AFB78AE");

                entity.ToTable("Libro");

                entity.Property(e => e.Autor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AñoPublicacion).HasColumnType("date");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
