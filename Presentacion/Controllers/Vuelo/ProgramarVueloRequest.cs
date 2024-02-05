namespace Presentacion.Controllers.Vuelo;
    public sealed record ProgramarVueloRequest(
     int CiudadOrigenId,
     int CiudadDestinoId,
     DateTime Fecha,
     TimeSpan HoraSalida,
     TimeSpan HoraLlegada,
     int AeroliniaId,
     Guid UsuarioCreacionId
   );

