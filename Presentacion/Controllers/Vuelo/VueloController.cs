using Aplicacion.Vuelo.GetVuelos;
using Aplicacion.Vuelo.ProgramacionVuelos;
using Domain.Shemas;
using Dominio.Abstracciones;
using Dominio.Vuelos;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers.Vuelo
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/vuelo")]
    public class VueloController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<VueloController> _logger;

        public VueloController(ILogger<VueloController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet("detalle/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<VueloScheme>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<VueloScheme>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjectResult))]
        public async Task<IActionResult> Detalle(int id, CancellationToken cancellationToken )
        {
			var query = new ObtenerVueloQuery(id);

            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado) : NotFound(resultado);
        }


        [HttpGet("{estado?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<List<VuelosScheme>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(VuelosScheme))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjectResult))]
        public async Task<IActionResult> List(CancellationToken cancellationToken, int? estado = null)
        {
            if (estado.HasValue)
            {
                var query = new ObtenerVuelosEstadoQuery((VueloEstado)estado.Value!);

                var resultado = await _sender.Send(query, cancellationToken);

                return resultado.IsSuccess ? Ok(resultado) : NotFound(resultado);
            }
            else
            {
                var query = new ObtenerVuelosQuery();

                var resultado = await _sender.Send(query, cancellationToken);

                return resultado.IsSuccess ? Ok(resultado) : NotFound(resultado);

            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProgramarVueloRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjectResult))]
        public async Task<IActionResult> Post([FromBody] ProgramarVueloRequest request, CancellationToken cancellationToken)
        {
            var userId =User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var command = new ProgramacionVueloCommand
            (
                request.CiudadOrigenId,
                request.CiudadDestinoId,
                request.Fecha,
                request.HoraSalida,
                request.HoraLlegada,
                request.AeroliniaId,
                Guid.Parse(userId)
            );

            var resultado = await _sender.Send(command, cancellationToken);

            return resultado.IsSuccess ? Created("", resultado) : BadRequest(resultado);
        }

        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] ActualizarProgramaRequest request, CancellationToken cancellationToken)
        //{
        //    var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromBody] EliminarProgramarVueloRequest request, CancellationToken cancellationToken)
        //{
        //    var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        //}
    }
}
