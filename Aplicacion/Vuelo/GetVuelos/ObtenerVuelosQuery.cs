namespace Aplicacion.Vuelo.GetVuelos
{
    using Aplicacion.Abstraciones.Messaging;
    using Domain.Shemas;
    using Dominio.Vuelos;

    public sealed record ObtenerVuelosQuery() : IQuery<List<VuelosScheme>>;
   
}
