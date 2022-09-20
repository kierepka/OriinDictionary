using Blazored.LocalStorage;

using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;

using Fluxor;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using OriinDictionary7;
using OriinDictionary7.Helpers;
using OriinDictionary7.Services;

using Toolbelt.Blazor.Extensions.DependencyInjection;
using Toolbelt.Blazor.I18nText;

<<<<<<< HEAD
namespace OriinDic;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        
=======
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
           .AddI18nText(options =>
           {
               options.PersistanceLevel = PersistanceLevel.SessionAndLocal;
           })
           .AddBlazorise()
           .AddBulmaProviders()
           .AddFontAwesomeIcons();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
>>>>>>> 0b50859ad62fc059ab90ef8d8a68a4980c5973ac

builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddScoped<AuthenticationStateProvider>();
builder.Services.AddScoped(provider =>
    provider.GetRequiredService<AuthenticationStateProvider>());

<<<<<<< HEAD

        builder.RootComponents.Add<App>("app");
        ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

        await builder.Build().RunAsync();
    }
    private static void ConfigureServices(IServiceCollection services, string baseAddress)
    {


        services
            .AddI18nText(options =>
            {
                options.PersistanceLevel = PersistanceLevel.SessionAndLocal;
            })
            .AddBlazorise()
            .AddBulmaProviders()
            .AddFontAwesomeIcons();

        services.AddScoped(sp =>
            new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            });

        services.AddBlazoredLocalStorage();
        services.AddScoped<AuthenticationStateProvider>();
        services.AddScoped<Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>(provider =>
            provider.GetRequiredService<AuthenticationStateProvider>());
        services.AddScoped<IAuthService, AuthService>();
        services.AddOptions();
        services.AddAuthorizationCore();
#if DEBUG
        services.AddLogging(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Debug));
#endif
        services.AddSpeechSynthesis();

        services.AddFluxor(o => o
            .ScanAssemblies(typeof(Program).Assembly)
            .UseReduxDevTools()
            .AddMiddleware<LoggingMiddleware>()
            .UseRouting());
    }
}
=======
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

#if DEBUG
builder.Services.AddLogging(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Debug));
#endif
builder.Services.AddSpeechSynthesis();

builder.Services.AddFluxor(o => o
    .ScanAssemblies(typeof(Program).Assembly)
    .UseReduxDevTools()
    .AddMiddleware<LoggingMiddleware>()
    .UseRouting());

await builder.Build().RunAsync();
>>>>>>> 0b50859ad62fc059ab90ef8d8a68a4980c5973ac
