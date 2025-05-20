using Microsoft.EntityFrameworkCore;
using ScholarMVC.BL.Services;
using ScholarMVC.DAL.Contexts;

namespace ScholarMVC.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connectStr = builder.Configuration.GetConnectionString("PC");
            builder.Services.AddDbContext<AppDbContext>(cs =>cs.UseSqlServer(connectStr));

            builder.Services.AddScoped<ScholarService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                
                name:"Default",
                pattern:"{controller=Home}/{action=Index}"
                
                );

            

            app.Run();
        }
    }
}
