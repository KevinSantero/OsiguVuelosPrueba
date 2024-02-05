namespace Aplicacion.Queries
{
    using Domain.Shemas;
    using Dominio.Vuelos;
    public interface IVueloQueries
    {
        Task<List<VuelosScheme>> ObtenerVuelos(VueloEstado estado);
        Task<List<VuelosScheme>> ObtenerVuelos();
        Task<VueloScheme?> ObtenerDetalleVuelo(int vueloId);
    }


}

