using EmailApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapControllerRoute(
    name: "Default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}");

app.MapControllerRoute(
    name: "Main",
    pattern: "Home/Index");

app.Run();
