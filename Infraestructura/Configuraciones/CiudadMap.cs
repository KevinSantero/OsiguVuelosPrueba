namespace Infraestructura.Configuraciones
{
    using Dominio.Ciudades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CiudadMap : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nombre)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.ToTable("Ciudades");
        }
    }
}
