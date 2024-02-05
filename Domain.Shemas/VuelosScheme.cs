namespace Domain.Shemas
{
    public sealed class VuelosScheme
    {
		public int Id { get; set; }
		public int NumeroVuelo { get;  set; }

        public string CiudadOrigen { get;  set; } = null!;
        public string CiudadDestino { get;  set; } = null!;

		public string NombreAerolinia { get; set; } = null!;

		public DateTime Fecha { get;  set; }

		public TimeSpan HoraSalida { get;  set; }

        public TimeSpan HoraLlegada { get;  set; }

        public string Aerolinea { get;  set; } = null!;

        public int Estado { get;  set; }

        public string UsuarioCreacion { get;  set; }
        public DateTime FechaCreacion { get;  set; }

        public string UsuarioActualizacion { get;  set; }
        public DateTime FechaActualizacion { get;  set; }

    }
}
