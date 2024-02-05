namespace Infraestructura.Configuraciones
{
    using Dominio.Usuario;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.Property(t => t.NombreUsuario)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.Property(t => t.Contrasena)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(t => t.Email)
             .HasMaxLength(200)
             .IsRequired();

            builder.Property(t => t.NombreUsuario)
             .IsRequired();

            builder.ToTable("Usuarios");
        }
    }
}
