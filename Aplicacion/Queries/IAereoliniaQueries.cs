namespace Aplicacion.Queries
{

    using Domain.Shemas;

    public interface IAereoliniaQueries
    {
        Task<List<AereolineaScheme>> ObtenerAereolinea();
    }
}
