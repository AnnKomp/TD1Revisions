using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorTD1Revisions.Services;
using System.Globalization;
using Microsoft.Extensions.Localization;
using Babylon.Blazor;
using Microsoft.JSInterop;

namespace BlazorTD1Revisions
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddScoped(sp => 
                new HttpClient { BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:7101") 
        });

            var host = builder.Build();

            
            var culture = new CultureInfo("fr-FR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            builder.Services.AddTransient<InstanceCreatorBase>(sp => new InstanceCreator(sp.GetService<IJSRuntime>()));

            await builder.Build().RunAsync();
        }
    }
}
