using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AplicacionCRUD.Models
{
    public partial class sistemaUsuariosContext : DbContext
    {
        public sistemaUsuariosContext()
        {
        }

        public sistemaUsuariosContext(DbContextOptions<sistemaUsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=sistemaUsuarios;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodigoUsuario);

                entity.ToTable("usuarios");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(64)
                    .HasColumnName("codigoUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
