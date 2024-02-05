using Blazored.SessionStorage;
using Domain.Shemas;
using System.Net.Http.Json;
using Web.Extencion;
using Web.Identity;
using Web.Services.Interface;

namespace Web.Services
{
    public class CiudadService : BaseHttp, ICiudadService
    {
        public CiudadService(HttpClient http
                , ISessionStorageService sessionStorageService
                , IConfiguration configuration) :base(http, sessionStorageService, configuration )
        {

        }
     
        public async Task<ResultResponse<List<CiudadSchema>>> ObtenerCiudad()
        {
            ResultResponse<List<CiudadSchema>> result = new();

            result.isSuccess = false;

            await SetearBearer();

            result = await _http.GetFromJsonAsync<ResultResponse<List<CiudadSchema>>>($"https://localhost:7044/api/Ciudad");

            return result;
        }
    }

}
