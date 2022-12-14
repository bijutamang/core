using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using coresystem;
using coresystem.Repositorys;
using coresystem.Repositorys.Interfaces;
using coresystem.Services;
using coresystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IDbConnectionProvider, DbConnectionProvider>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<ISharePurchaseRepository, SharePurchaseRepository>();
builder.Services.AddTransient<ISharePurchaseService, SharePurchaseService>();
builder.Services.AddTransient<IShareReturnRepository, ShareReturnRepository>();
builder.Services.AddTransient<IShareReturnService, ShareReturnService>();

// configure toast notification
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseNotyf();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
