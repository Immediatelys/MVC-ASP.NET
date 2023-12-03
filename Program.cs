
//~ConfigureServices
using ASP_MVC.Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();
services.AddDistributedMemoryCache();
services.AddSession(cfg =>
{
    cfg.Cookie.Name = "xuanthulab";
    cfg.IdleTimeout = new TimeSpan(0, 30, 0);
});
services.AddRazorPages();

services.AddSingleton<ProductService>();

//~Configure
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

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();


public class Startup
{
    public static string ContentRootPath { get; set; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        ContentRootPath = env.ContentRootPath;

    }
}