var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var app = builder.Build();

app.MapControllerRoute(
    name: "Default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}");

app.MapControllerRoute(
    name: "Main",
    pattern: "Home/Index");

app.Run();
