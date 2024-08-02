﻿using Colegio.Data;
using Microsoft.EntityFrameworkCore;

namespace Colegio
{
    public static class Startup
    {
        public static WebApplication InicializarApp(string[] args) {

            var builder = WebApplication.CreateBuilder(args);
            Configureservices(builder);

            var app = builder.Build();
            Configure(app);

            return app;
        }
        private static void Configureservices(WebApplicationBuilder builder) {

            builder.Services.AddDbContext<ColegioContext>(options => options.UseInMemoryDatabase("ColecioDb"));
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
        }

        private static void Configure(WebApplication app) {
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
        }
    }
}
