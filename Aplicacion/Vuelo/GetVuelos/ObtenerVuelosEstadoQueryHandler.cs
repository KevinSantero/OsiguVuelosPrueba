namespace Aplicacion.Vuelo.GetVuelos
{
    using Aplicacion.Abstraciones.Messaging;
    using Aplicacion.Queries;
    using Domain.Shemas;
    using Dominio.Abstracciones;
    using System.Collections.Generic;

    internal sealed class ObtenerVuelosEstadoQueryHandler : IQueryHandler<ObtenerVuelosEstadoQuery, List<VuelosScheme>>
    {
        private readonly IVueloQueries _vueloQueries;
        public ObtenerVuelosEstadoQueryHandler(IVueloQueries vueloQueries)
        {
            _vueloQueries = vueloQueries;
        }
        public async Task<Result<List<VuelosScheme>>> Handle(ObtenerVuelosEstadoQuery request, CancellationToken cancellationToken)
        {
            return Result.Success(await _vueloQueries.ObtenerVuelos(request.estado));
        }
    }
}
