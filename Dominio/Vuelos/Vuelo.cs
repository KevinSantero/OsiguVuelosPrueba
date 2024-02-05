namespace Dominio.Vuelos
{
    using Dominio.Abstracciones;
    using Dominio.Aerolineas;
    using Dominio.Ciudades;
    using Dominio.Usuario;
    using Dominio.Usuarios;

    public  class Vuelo: BaseEntity<int>
    {
        public Vuelo() { }

        private Vuelo(
             int numeroVuelo,
             int ciudadOrigen,
             int ciudadDestino,
             DateTime fecha,
             TimeSpan horaSalida,
             TimeSpan horaLlegada,
             int aerolineaId,
             VueloEstado vueloEstado,
             Guid usuarioCreacionId,
             DateTime fechaCreacion
            ) {

            NumeroVuelo = numeroVuelo;
            CiudadOrigenId = ciudadOrigen;
            CiudadDestinoId = ciudadDestino;
            Fecha = fecha;
            HoraSalida = horaSalida;
            HoraSalida = horaSalida;
            AerolineaId = aerolineaId;
            Estado = vueloEstado;
            UsuarioCreacionId = usuarioCreacionId;
            FechaCreacion = fechaCreacion;
        }

        public int NumeroVuelo { get;  private set; }
        public int CiudadOrigenId { get; private set; }
        public int CiudadDestinoId { get;  private set; }

        public DateTime Fecha { get; private set; }

        public TimeSpan HoraSalida { get; private set; }

        public TimeSpan HoraLlegada { get; private set; }

        public int AerolineaId { get; private set; }

        public VueloEstado Estado { get; private set; }

        public Guid UsuarioCreacionId { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public Guid? UsuarioActualizacionId { get; private set; }
        public DateTime? FechaActualizacion { get; private set; }

        public virtual Ciudad CiudadOrigen { get; private set; }
        public virtual Ciudad CiudadDestino { get; private set; }
        public virtual Aerolinea Aerolinea { get; private set; }

        public virtual Usuario UsuarioCreacion { get; private set; }

        public virtual Usuario UsuarioActualizacion { get; private set; }

        public static Vuelo Programar(
                int ciudadOrigen,
                int ciudadDestino,
                DateTime fecha,
                TimeSpan horaSalida,
                TimeSpan horaLlegada,
                int aerolineaId,
                Guid usuarioCreacionId
                ) {

            if (horaSalida == horaLlegada)
            {
                throw new
                ApplicationException("La hora salida es igual la hora de llegada");
            }

            if (horaSalida > horaLlegada)
            {
                throw new
                ApplicationException("La hora salida es anterio a la horas de llegada");
            }

            if (ciudadOrigen == ciudadDestino)
            {
                throw new
                ApplicationException("La ciudad de origen y destino no puede ser iguales");
            }

            var nuevoNumeroDeVuelo = NuevoNumeroDeVuelo();

            var vuelo = new Vuelo(
                nuevoNumeroDeVuelo,
                ciudadOrigen,
                ciudadDestino,
                fecha,
                horaSalida, 
                horaLlegada,
                aerolineaId,
                VueloEstado.Saliente,
                usuarioCreacionId,
                DateTime.Now
                );

            //en caso de realizar una acion extenerna para la creacion del vuelo
            //vuelo.RaiseDomainEvent(new VuelosProgramadosDomainEvent(vuelo.Id!));

            return vuelo;

        }

        public Result ActualizarEstado(Guid usuarioId, VueloEstado estado)
        {
            if (estado == VueloEstado.Completado)
            {
                return Result.Failure(VueloErrors.TripComplete);
            }

            Estado = VueloEstado.Completado;
            UsuarioActualizacionId = usuarioId;
            FechaActualizacion = DateTime.Now;
            //RaiseDomainEvent(new AlquilerConfirmadoDomainEvent(Id));
            return Result.Success();
        }

        private static int NuevoNumeroDeVuelo() {

            var rand = new Random();
            int numeroAno = DateTime.Now.Year* 1000;
            int numeroRandon = rand.Next( 1,1000 );

            return numeroAno + numeroRandon;
        }


    }
}
