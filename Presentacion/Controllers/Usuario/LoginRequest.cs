namespace Api.Controllers.Usuario;
public sealed record LoginRequest(
 string NombreUsuario,
 string Contrasena
);

