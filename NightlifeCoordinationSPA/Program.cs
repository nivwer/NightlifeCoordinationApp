using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using MudBlazor.Services;
using NightlifeCoordinationSPA;
using NightlifeCoordinationSPA.Providers.AuthStateProvider;
using NightlifeCoordinationSPA.Services.AuthService;
using NightlifeCoordinationSPA.Services.BusinessesService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient(new CookieHandler())
{
    BaseAddress = new Uri("http://localhost:5264")
});

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBusinessesService, BusinessesService>();

await builder.Build().RunAsync();

public class CookieHandler : DelegatingHandler
{
    public CookieHandler()
    {
        InnerHandler = new HttpClientHandler();
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        return base.SendAsync(request, cancellationToken);
    }
}
