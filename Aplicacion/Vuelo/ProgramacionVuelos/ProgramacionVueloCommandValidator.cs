using Aplicacion.Vuelo.ProgramacionVuelos;
using FluentValidation;

namespace Aplicacion.Usuario.Login
{
    public class ProgramacionVueloCommandValidator : AbstractValidator<ProgramacionVueloCommand>
    {
        public ProgramacionVueloCommandValidator()
        {
            RuleFor(c => c.CiudadOrigenId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("debe serleccionar  una ciudad origen");

            RuleFor(c => c.CiudadDestinoId)
                 .GreaterThanOrEqualTo(1)
                 .WithMessage("debe serleccionar  una ciudad destino");

            RuleFor(f =>
            f.Fecha).NotEmpty().WithMessage("La fecha es requerida");

            RuleFor(f =>
            f.HoraSalida).NotEmpty().WithMessage("La hora de salida es requerida");

            RuleFor(f =>
            f.HoraLlegada).NotEmpty().WithMessage("La hora de salida es requerida");

            RuleFor(f =>
            f.UsuarioCreacionId).NotEmpty().WithMessage("El usuario de creacion es requerido");
        }
    }
}
