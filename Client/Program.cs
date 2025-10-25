using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Configure HttpClient pointing to the API server base URL.
// If server runs on https://localhost:5001, set that here when running locally.
// We'll set via appsettings or env; for simplicity, use relative URL if hosted with a proxy.
// You can change "https://localhost:5001" to your server base address during dev.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Post service
builder.Services.AddScoped<PostService>();

await builder.Build().RunAsync();
