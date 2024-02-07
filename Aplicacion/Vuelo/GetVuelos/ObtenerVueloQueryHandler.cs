namespace Aplicacion.Vuelo.GetVuelos
{
    using Aplicacion.Abstraciones.Messaging;
    using Aplicacion.Queries;
    using Domain.Shemas;
    using Dominio.Abstracciones;
    using Dominio.Usuarios;

    internal sealed class ObtenerVueloQueryHandler : IQueryHandler<ObtenerVueloQuery, VueloScheme?>
    {
        private readonly IVueloQueries _vueloQueries;
        public ObtenerVueloQueryHandler(IVueloQueries vueloQueries)
        {
            _vueloQueries = vueloQueries;
        }
        public async Task<Result<VueloScheme?>> Handle(ObtenerVueloQuery request, CancellationToken cancellationToken)
        {
            if (request.id == 0)
            {
                return Result.Failure<VueloScheme?>(VueloErrors.IdEmpety);
            }

			var vuelo = (await _vueloQueries.ObtenerDetalleVuelo(request.id))!;

            if (vuelo==null)
            {
                return Result.Failure<VueloScheme?>(VueloErrors.NotFound);
            }

            return Result.Success(vuelo);
        }
    }
}
