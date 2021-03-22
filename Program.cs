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

namespace OriinDic
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            

            builder.Services
                .AddI18nText(options =>
                {
                    options.PersistanceLevel = PersistanceLevel.SessionAndLocal;
                })
                .AddBlazorise(options => { options.ChangeTextOnKeyPress = false; })                       
                .AddBulmaProviders()
                .AddFontAwesomeIcons();
            
            builder.Services.AddScoped(sp => 
                new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<AuthenticationStateProvider>();
            builder.Services.AddScoped<Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>(provider =>
                provider.GetRequiredService<AuthenticationStateProvider>());
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


            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

       

            await host.RunAsync();
        }
    }
}