using EmailApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Authorization");
builder.Services.AddAuthorization();

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}");

app.MapControllerRoute(
    name: "Main",
    pattern: "Home/Index");
app.MapControllerRoute(
    name: "Profile",
    pattern: "Authorized/Profile");

app.Run();
