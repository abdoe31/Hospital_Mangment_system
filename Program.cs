using Data_Access_Layer;
using Microsoft.EntityFrameworkCore;
using BL;
namespace DAY4_7
   
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connection = builder.Configuration.GetConnectionString("hospital");
            builder.Services.AddDbContext<Hostpital_Context>(op=> op.UseSqlServer(connection));
            builder.Services.AddScoped <IDoctorrepo,Doctorrepo>() ;
            builder.Services.AddScoped<IPatientrepo, Patientrepo>();
            builder.Services.AddScoped<Iunit, Unit>();
            builder.Services.AddScoped<Idoctormanger, DoctorManger>();



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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}