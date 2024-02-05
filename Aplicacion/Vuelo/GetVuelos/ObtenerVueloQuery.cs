namespace Aplicacion.Vuelo.GetVuelos
{
    using Aplicacion.Abstraciones.Messaging;
    using Domain.Shemas;

    public sealed record ObtenerVueloQuery(int id) : IQuery<VueloScheme?>;
   
}
