using Microsoft.EntityFrameworkCore;
using Ralfy_Genao_P2_AP1.Components;
using Ralfy_Genao_P2_AP1.DAL;
using Ralfy_Genao_P2_AP1.Service;

var builder = WebApplication.CreateBuilder(args);
var conStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(conStr));

builder.Services.AddScoped<CiudadServices>();
builder.Services.AddScoped<EncuestaServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
