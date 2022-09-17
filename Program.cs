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

builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddScoped<AuthenticationStateProvider>();
builder.Services.AddScoped(provider =>
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

await builder.Build().RunAsync();
