using BlazorCrudDotNet8.Client.Services.Interfaces;
using BlazorCrudDotNet8.Client.Services.Repositories;
using BlazorCrudDotNet8.Shared.Data;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));

//builder.Services.AddHttpClient<IVehicleService, VehicleService>(client => {
//    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
//});

builder.Services.AddScoped<IGRepository<Game>, GRepository<Game>>();
var serviceProvider = builder.Services.BuildServiceProvider();
var repo = serviceProvider.GetService<IGRepository<Game>>();
Console.WriteLine(repo);

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});


builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
