using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Web.Identity
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResultResponse<string>?> Login(AuthRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("usuario", request);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var deserlizado = JsonConvert.DeserializeObject<ResultResponse<string>>(content);
                return deserlizado;
            }
            else
            {
                var content = await result.Content.ReadAsStringAsync();
                var deserlizado = JsonConvert.DeserializeObject<ResultResponse<string>>(content);
                return deserlizado;
            }
        }
        public async Task<bool> Register(RegisterRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("auth/register", request);
            return result.IsSuccessStatusCode;
        }
    }
}
