using Aplicacion.Usuario.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers.Usuario
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LoginRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjectResult))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = new UsuarioLoginCommand(
                 request.NombreUsuario,
                 request.Contrasena );

            var resultado = await _sender.Send(command, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado) : Unauthorized(resultado);
        }


    }
}
