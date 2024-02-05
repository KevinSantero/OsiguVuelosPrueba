using Domain.Shemas;

namespace Aplicacion.Queries
{
    public interface ICiudadQueries
    {
        Task<List<CiudadSchema>> ObtenerCiudades();
    }
}
