using Blazored.SessionStorage;
using System.Net.Http.Headers;

namespace Web.Extencion
{
    public class BaseHttp
    {
        public readonly HttpClient _http;
        public readonly ISessionStorageService _sessionStorageService;
        public readonly IConfiguration _configuration;
        public BaseHttp(HttpClient http
                , ISessionStorageService sessionStorageService
                , IConfiguration configuration)
        {
            _http = http;
            _sessionStorageService = sessionStorageService;
            _configuration = configuration;
        }
      
        public async Task SetearBearer()
        {
            var token = await _sessionStorageService.GetItemAsync<string>("token");
            if (token == null)
            {
            }
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        }
    }
}
