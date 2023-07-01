using WebBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Necessario apenas para o page fetchdata
builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

string apiBaseAddress = builder.Configuration["ApiUrl"];

builder.Services.AddHttpClient<IArquivoService, ArquivoService>(client =>
{
    client.BaseAddress = new Uri(apiBaseAddress);
});

await builder.Build().RunAsync();
