using Domain.Shemas;
using Web.Identity;

namespace Web.Services.Interface
{
	public interface IVueloService
	{
		Task<ResultResponse<List<VuelosScheme>>> ObtenerVuelos(int estado);
        Task<ResultResponse<VueloScheme>> ObtenerVueloDetalle(int id);

        Task<ResultResponse<int>> ProgramarVuelo(ProgramarVueloScheme vuelo);
    }
}
