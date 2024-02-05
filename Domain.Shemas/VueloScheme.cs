namespace Domain.Shemas
{
    public sealed class VueloScheme
    {
        public int Id { get;  set; }
        public int NumeroVuelo { get;  set; }
        public int CiudadOrigenId { get;  set; }
        public int CiudadDestinoId { get;  set; }
		public string CiudadOrigen { get; set; }
		public string CiudadDestino { get; set; }

		public DateTime Fecha { get;  set; }

        public TimeSpan HoraSalida { get; set; }

        public TimeSpan HoraLlegada { get;   set; }

        public int AerolineaId { get; set; }

		public string NombreAerolinia { get; set; } = null!;

		public int Estado { get; set; }

        public Guid UsuarioCreacionId { get; set; }
		public string UsuarioCreacion { get; set; }
		public DateTime FechaCreacion { get; set; }
        public Guid UsuarioActualizacionId { get; set; }

		public string UsuarioActualizacion { get; set; }
		public DateTime FechaActualizacion { get; set; }

    }
}
