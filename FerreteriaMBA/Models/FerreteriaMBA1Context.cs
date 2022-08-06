using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FerreteriaMBA.Models
{
    public partial class FerreteriaMBA1Context : DbContext
    {
        public FerreteriaMBA1Context()
        {
        }

        public FerreteriaMBA1Context(DbContextOptions<FerreteriaMBA1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Codigo> Codigos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=FerreteriaMBA1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__CD54BC5A23B1DA75");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Codigo>(entity =>
            {
                entity.HasKey(e => e.IdCodigo)
                    .HasName("PK__Codigo__F32CBC5278EC11FA");

                entity.ToTable("Codigo");

                entity.Property(e => e.IdCodigo).HasColumnName("id_codigo");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Codigo");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Codigos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__Codigo__id_produ__29572725");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__FF341C0D29108988");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Productos__id_ca__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
