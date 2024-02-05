using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;
using Web.Extencion;
using Web.Identity;
using Web.Services;
using Web.Services.Interface;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7044/api/" ) });

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddScoped<ICiudadService, CiudadService>();

builder.Services.AddScoped<IAereoliniaService, AereoliniaService>();

//Base para apuntar a las api
builder.Services.AddHttpClient<AuthService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:7044/api/");
});

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
