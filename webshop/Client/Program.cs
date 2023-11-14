using System;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using webshop.Client;
using webshop.Client.Services;

namespace webshop.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Services.AddScoped(sp => new HttpClient {
                 BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        });

        /*Denne skal bruges hvis den klasse som implementere IBikeService
          har en konstruktør med HttpClient

        builder.Services.AddHttpClient<IBikeService, BikeServiceInMemory>(client =>
        {
            client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
        });*/

        // denne kan anvendes, hvis den klasse som implementere IBikeService
        // har en tom konstruktør
        builder.Services.AddSingleton<IBikeService, BikeServiceInMemory>();

        await builder.Build().RunAsync();
    }
}

