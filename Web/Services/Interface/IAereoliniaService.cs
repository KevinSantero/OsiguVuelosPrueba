using Domain.Shemas;
using Web.Identity;

namespace Web.Services.Interface
{
	public interface IAereoliniaService
	{
		Task<ResultResponse<List<AereolineaScheme>>> ObtenerAereolinia();
    }
}
