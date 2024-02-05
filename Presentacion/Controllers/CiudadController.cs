
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
    [Route("api/Ciudad")]
    public class CiudadController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<CiudadController> _logger;

        public CiudadController(ILogger<CiudadController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<List<CiudadSchema>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type= typeof(Result<List<CiudadSchema>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjectResult))]

        public async Task<IActionResult> Select(CancellationToken cancellationToken)
        {
            var query = new ObtenerCiudadQuery();

            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado) : NotFound(resultado);
        }

       
    }
}