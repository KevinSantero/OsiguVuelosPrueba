using Domain.Shemas;
using Web.Identity;

namespace Web.Services.Interface
{
	public interface ICiudadService
	{
		Task<ResultResponse<List<CiudadSchema>>> ObtenerCiudad();
    }
}
