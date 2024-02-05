using System.ComponentModel.DataAnnotations;

namespace Domain.Shemas
{
	public class ProgramarVueloScheme
	{
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
		public int CiudadOrigenId { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
		public int CiudadDestinoId { get; set; }

		[Required(ErrorMessage = "El campo {0} es requerido.")]
		public DateTime Fecha { get; set; }

		public TimeSpan HoraSalida { get; set; }

		public TimeSpan HoraLlegada { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
		public int AeroliniaId { get; set; }

		[Required(ErrorMessage = "El campo {0} es requerido.")]
		public Guid UsuarioCreacionId { get; set; }

	}
}
