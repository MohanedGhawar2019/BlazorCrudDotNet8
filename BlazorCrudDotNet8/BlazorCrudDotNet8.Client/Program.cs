using BlazorCrudDotNet8.Shared.Services.Interfaces;
using BlazorCrudDotNet8.Shared.Services.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

//builder.Services.AddScoped(typeof(IGRepository<>), typeof(CService<>));

builder.Services.AddScoped<IGameService, CService>();

await builder.Build().RunAsync();
