namespace Aplicacion.Vuelo.GetVuelos
{
    using Aplicacion.Abstraciones.Messaging;
    using Domain.Shemas;
    using Dominio.Vuelos;

    public sealed record ObtenerVuelosEstadoQuery(VueloEstado estado) : IQuery<List<VuelosScheme>>;
   
}
