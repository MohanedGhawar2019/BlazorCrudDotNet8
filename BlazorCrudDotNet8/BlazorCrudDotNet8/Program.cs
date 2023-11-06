using BlazorCrudDotNet8.Client.Pages;
using BlazorCrudDotNet8.Components;
using BlazorCrudDotNet8.Models;
using BlazorCrudDotNet8.Models.Entities;
using BlazorCrudDotNet8.Models.Interfaces;
using BlazorCrudDotNet8.Models.UnitOfWork;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); // When selecting nested data (include)

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!),
});

// ********************* Connection String ***************************
builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

//===== Identity setting =====
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<DataContext>()
                 .AddDefaultTokenProviders();

// ===== Unit of work setting =====
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
