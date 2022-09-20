using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OriinDic.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OriinDic.Helpers;
using Toolbelt.Blazor.I18nText;
using AuthenticationStateProvider = OriinDic.Services.ApiAuthenticationStateProvider;

namespace OriinDic;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        



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