using Dominio.Abstracciones;

namespace Dominio.Usuarios
{
    public static class UsuarioErrors
    {
        public static Error NotFound = new(
     "User.Found",
     "No existe el usuario buscado por este id"
 );

        public static Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "Las credenciales son incorrectas"
        );

    }
}
