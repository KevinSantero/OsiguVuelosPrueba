using Blazored.SessionStorage;
using Domain.Shemas;
using System.Net.Http.Json;
using Web.Extencion;
using Web.Identity;
using Web.Services.Interface;


namespace Web.Services
{

    public class VueloService : BaseHttp,IVueloService 
	{
        public VueloService(HttpClient http
                , ISessionStorageService sessionStorageService
                , IConfiguration configuration) :base(http, sessionStorageService, configuration )
        {

        }
     
        public async Task<ResultResponse<List<VuelosScheme>>> ObtenerVuelos(int estado=1) {

			ResultResponse<List<VuelosScheme>> result = new();

			result.isSuccess = false;

            await SetearBearer();

			result = await _http.GetFromJsonAsync<ResultResponse<List<VuelosScheme>>>($"https://localhost:7044/api/vuelo/{estado}");

			return result;
		}

        public async Task<ResultResponse<VueloScheme>> ObtenerVueloDetalle(int id)
        {
            ResultResponse<VueloScheme> result = new();

            result.isSuccess = false;

            await SetearBearer();

            result = await _http.GetFromJsonAsync<ResultResponse<VueloScheme>>($"https://localhost:7044/api/vuelo/detalle/{id}");

            return result;
        }

        public async Task<ResultResponse<int>> ProgramarVuelo(ProgramarVueloScheme vuelo)
        {
            ResultResponse<int> result = new();
            result.isSuccess = false;

            await SetearBearer();

            var response = await _http.PostAsJsonAsync("https://localhost:7044/api/vuelo", vuelo);

            result = await response.Content.ReadFromJsonAsync<ResultResponse<int>>();

            return result;
        }
    }

}
