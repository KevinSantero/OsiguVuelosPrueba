using Aplicacion.Abstraciones.Messaging;
using Aplicacion.Queries;
using Domain.Shemas;
using Dominio.Abstracciones;

internal sealed class ObtenerAereoliniasQueryHandler : IQueryHandler<ObtenerAereoliniasQuery, List<AereolineaScheme>>
{
    private readonly IAereoliniaQueries _aereoliniaQueries;
    public ObtenerAereoliniasQueryHandler(IAereoliniaQueries aereoliniaQueries)
    {
        _aereoliniaQueries = aereoliniaQueries;
    }
    public async Task<Result<List<AereolineaScheme>>> Handle(ObtenerAereoliniasQuery request, CancellationToken cancellationToken)
    {
        return await _aereoliniaQueries.ObtenerAereolinea();
    }
}