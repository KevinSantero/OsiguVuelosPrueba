using FluentValidation;

namespace Aplicacion.Usuario.Login
{
    public class UsuarioLoginCommandValidator : AbstractValidator<UsuarioLoginCommand>
    {
        public UsuarioLoginCommandValidator()
        {
            RuleFor(c => c.NombreUsuario).NotEmpty();
            RuleFor(c => c.Contrasena).NotEmpty();
        }
    }
}
