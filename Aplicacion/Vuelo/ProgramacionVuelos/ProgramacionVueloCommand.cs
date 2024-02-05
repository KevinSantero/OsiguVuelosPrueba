using Aplicacion.Abstraciones.Messaging;

namespace Aplicacion.Vuelo.ProgramacionVuelos
{
    public record ProgramacionVueloCommand(
     int CiudadOrigenId,
     int CiudadDestinoId,
     DateTime Fecha,
     TimeSpan HoraSalida,
     TimeSpan HoraLlegada,
     int AeroliniaId,
     Guid UsuarioCreacionId

     ) : ICommand<int>;
}
