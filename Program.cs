using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Detektivspiel;
using Detektivspiel.Controllers;
using Detektivspiel.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<GameController>();
builder.Services.AddSingleton<SupabaseService>();

var app = builder.Build();

var supabase = app.Services.GetRequiredService<SupabaseService>();
await supabase.InitializeAsync();

await app.RunAsync();
