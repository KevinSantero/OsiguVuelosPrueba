using Domain.Shemas;
using Dominio.Abstracciones;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/aereolinia")]
    public class AereoliniaController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<AereoliniaController> _logger;

        public AereoliniaController(ILogger<AereoliniaController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<List<AereolineaScheme>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type= typeof(Result<List<CiudadSchema>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjectResult))]
        public async Task<IActionResult> Select(CancellationToken cancellationToken)
        {
            var query = new ObtenerAereoliniasQuery();

            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado) : NotFound(resultado);
        }

       
    }
}