using AM.Applicationcore.Interfaces;
using AM.ApplicationCore.Interfaces;
using AM.Applicationcore.Services;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AM.UI.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IServiceFlight, ServiceFlight>();
            builder.Services.AddScoped<IServicePlane, ServicePlane>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddDbContext<DbContext, AmContext>();
            builder.Services.AddSingleton<Type>(T => typeof(GenericRepository<>));
            builder.Services.AddScoped<IServicePlane, ServicePlane>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}