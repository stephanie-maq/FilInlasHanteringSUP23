using FISSUP23.Database.Models;
using FISSUP23.Server.Services;
using FISSUP23.Server.Services.Interface;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews().AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
    services.AddRazorPages();
    services.AddSwaggerGen();
    services.AddScoped<IOverforingService, OverforingService>();
    services.AddScoped<IFilkollektionService, FilkollektionService>();
    services.AddScoped<IFilService, FilService>();
    services.AddScoped<IKolumnService, KolumnService>();
    services.AddScoped<IProcessdataService, ProcessdataService>();
    
    services.AddDbContext<SsisGenericReadContext>(options =>
    {
        options.ConfigureWarnings(warnings =>
                
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    });
}