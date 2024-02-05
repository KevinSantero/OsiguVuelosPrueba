using Aplicacion.Abstraciones.Messaging;
using Dominio.Abstracciones;
using Dominio.Usuario;
using Dominio.Usuarios;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aplicacion.Usuario.Login
{
    internal class UsuarioLoginCommandHandler : ICommandHandler<UsuarioLoginCommand, string>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        public UsuarioLoginCommandHandler(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }
        public async Task<Result<string>> Handle(UsuarioLoginCommand request, CancellationToken cancellationToken)
        {
            var usuario= await _usuarioRepository.ObtenerUsuario(request.NombreUsuario, request.Contrasena, cancellationToken);

            if(usuario == null) {
                return Result.Failure<string>(UsuarioErrors.InvalidCredentials);
            }

            var token = ObtenerToken();

            return Result.Success(token);

            string ObtenerToken()
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
              
                //informacion del usuario
                var claims = new List<Claim> {
                     new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                     new Claim(ClaimTypes.Email, usuario.Email)
                };

                //agrego un rol
                claims.Add(new Claim(ClaimTypes.Role, "Administrador"));
                
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = issuer,
                    Audience = audience,
                    Subject = new ClaimsIdentity(claims.ToArray()),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}
