using Blazored.SessionStorage;
using Domain.Shemas;
using System.Net.Http.Json;
using Web.Extencion;
using Web.Identity;
using Web.Services.Interface;

namespace Web.Services
{
      public class AereoliniaService : BaseHttp, IAereoliniaService
       {
        public AereoliniaService(HttpClient http
                , ISessionStorageService sessionStorageService
                , IConfiguration configuration) :base(http, sessionStorageService, configuration )
        {

        }
     
        public async Task<ResultResponse<List<AereolineaScheme>>> ObtenerAereolinia()
        {
            ResultResponse<List<AereolineaScheme>> result = new();

            result.isSuccess = false;

            await SetearBearer();

            result = await _http.GetFromJsonAsync<ResultResponse<List<AereolineaScheme>>>($"https://localhost:7044/api/aereolinia");

            return result;
        }
    }

}
