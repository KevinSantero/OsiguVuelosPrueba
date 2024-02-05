namespace Aplicacion.Vuelo.GetVuelos;

using Aplicacion.Abstraciones.Messaging;
using Aplicacion.Queries;
using Domain.Shemas;
using Dominio.Abstracciones;
using System.Collections.Generic;

internal sealed class ObtenerVuelosQueryHandler : IQueryHandler<ObtenerVuelosQuery, List<VuelosScheme>>
{
    private readonly IVueloQueries _vueloQueries;
    public ObtenerVuelosQueryHandler(IVueloQueries vueloQueries)
    {
        _vueloQueries = vueloQueries;
    }
    public async Task<Result<List<VuelosScheme>>> Handle(ObtenerVuelosQuery request, CancellationToken cancellationToken)
    {
        return Result.Success(await _vueloQueries.ObtenerVuelos());
    }
}

