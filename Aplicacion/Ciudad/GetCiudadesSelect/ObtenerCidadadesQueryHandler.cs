using Aplicacion.Abstraciones.Messaging;
using Aplicacion.Queries;
using Domain.Shemas;
using Dominio.Abstracciones;

internal sealed class ObtenerCidadadesQueryHandler : IQueryHandler<ObtenerCiudadQuery, List<CiudadSchema>>
{
    private readonly ICiudadQueries _ciudadQueries;
    public ObtenerCidadadesQueryHandler(ICiudadQueries ciudadQueries)
    {
        _ciudadQueries = ciudadQueries;
    }
    public async Task<Result<List<CiudadSchema>>> Handle(ObtenerCiudadQuery request, CancellationToken cancellationToken)
    {
        return await _ciudadQueries.ObtenerCiudades();
    }
}