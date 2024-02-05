namespace Infraestructura.Configuraciones
{
    using Dominio.Aerolineas;
    using Dominio.Vuelos;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class VueloMap : IEntityTypeConfiguration<Vuelo>
    {
        public void Configure(EntityTypeBuilder<Vuelo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.NumeroVuelo)
                 .IsRequired();

            builder.Property(t => t.CiudadOrigenId)
                  .IsRequired();

            builder.Property(t => t.CiudadDestinoId)
                 .IsRequired();

            builder.Property(t => t.Fecha)
                 .IsRequired();

              builder.Property(t => t.HoraSalida)
              .IsRequired();

                builder.Property(t => t.HoraLlegada)
              .IsRequired();


            //Auditoria

            builder.Property(t => t.UsuarioCreacionId)
              .IsRequired();

            builder.Property(t => t.FechaCreacion)
            .IsRequired();

            builder.Property(t => t.UsuarioActualizacionId).IsRequired(false);

            builder.Property(t => t.FechaActualizacion)
		     .IsRequired(false);

			builder.ToTable("Vuelos");

            builder.HasOne(x => x.CiudadOrigen)
             .WithMany(x => x.VuelosOrigen)
             .HasForeignKey(x => x.CiudadOrigenId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CiudadDestino)
             .WithMany(x => x.VuelosDestino)
             .HasForeignKey(x => x.CiudadDestinoId)
              .OnDelete(DeleteBehavior.NoAction);

             builder.HasOne(x => x.Aerolinea)
             .WithMany(x => x.Vuelos)
             .HasForeignKey(x => x.AerolineaId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.UsuarioCreacion)
           .WithMany(x => x.VueloUsuaioCreacion)
           .HasForeignKey(x => x.UsuarioCreacionId)
            .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.UsuarioActualizacion)
           .WithMany(x => x.VueloUsuaioActualizacion)
           .HasForeignKey(x => x.UsuarioActualizacionId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
