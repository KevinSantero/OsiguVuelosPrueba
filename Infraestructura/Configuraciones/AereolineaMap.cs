namespace Infraestructura.Configuraciones
{
    using Dominio.Aerolineas;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AereolineaMap : IEntityTypeConfiguration<Aerolinea>
    {
        public void Configure(EntityTypeBuilder<Aerolinea> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nombre)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.ToTable("Aereolinias");
        }
    }
}
