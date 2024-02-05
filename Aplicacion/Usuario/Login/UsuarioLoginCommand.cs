using Aplicacion.Abstraciones.Messaging;
namespace Aplicacion.Usuario.Login
{

    public record UsuarioLoginCommand(
     string NombreUsuario,
     string Contrasena

     ) : ICommand<string>;
}
