using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAPIClient;
using BlazorAPIClient.DataServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient {BaseAddress = new Uri(builder.Configuration["api_base_url"]!)});

builder.Services.AddHttpClient<IRickAndMortyDataService, GraphQLRickAndMortyDataService>(client =>
    client.BaseAddress = new Uri(builder.Configuration["api_base_url"]!));

await builder.Build().RunAsync();