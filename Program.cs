using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OriinDic.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Toolbelt.Blazor.I18nText;

namespace OriinDic
{
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            

            builder.Services
                .AddBlazorise(options => { options.ChangeTextOnKeyPress = false; })
                .AddI18nText(options =>
                {
                     options.PersistanceLevel = PersistanceLevel.SessionAndLocal;
                })
                .AddBulmaProviders()
                .AddFontAwesomeIcons();
            //builder.Services.AddSingleton(new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
                provider.GetRequiredService<ApiAuthenticationStateProvider>());
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddLogging(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Debug));
            builder.Services.AddSpeechSynthesis();


            builder.Services.AddFluxor(options =>
            {
                options
                    .ScanAssemblies(typeof(Program).Assembly);
                    //.UseReduxDevTools(); // For ReduxDevTool support. Recommended to remove this on Production
            });

            //builder.Services.AddFluxor(o => o
            //    .ScanAssemblies(typeof(Program).Assembly)
            //    .UseReduxDevTools()
            //    .AddMiddleware<LoggingMiddleware>()
            //    .UseRouting());
           

            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            host.Services
                .UseBulmaProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}