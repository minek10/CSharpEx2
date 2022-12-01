using DemoApp.Services;
using DemoApp.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Sotsera.Blazor.Toaster.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<HttpClient>(s =>
{
    var client = new HttpClient { BaseAddress = new Uri("https://localhost:7171/") };
    return client;
});

#region SERVICES
builder.Services.AddScoped<IUserService, UserService>();
#endregion

#region Toaster
builder.Services.AddToaster(config =>
{
    //Customizations
    config.PositionClass = Defaults.Classes.Position.BottomRight;
    config.PreventDuplicates = false;
    config.NewestOnTop = true;
});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
