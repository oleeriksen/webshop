﻿using Microsoft.AspNetCore.Components.Web;
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
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddHttpClient<IBikeService, BikeService>(client =>
        {
            client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
        });
        await builder.Build().RunAsync();
    }
}

