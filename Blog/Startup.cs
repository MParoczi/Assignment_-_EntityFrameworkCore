using System;
using Blog.Data.Contexts;
using Blog.Data.Resources;
using dotenv.net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            DotEnv.Config(filePath: "connection.env");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var host = Environment.GetEnvironmentVariable("HOST");
            var database = Environment.GetEnvironmentVariable("DATABASE");
            var name = Environment.GetEnvironmentVariable("USERNAME");
            var password = Environment.GetEnvironmentVariable("PASSWORD");

            services.AddControllersWithViews();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<BlogContext>((sp, opt) =>
                    opt.UseNpgsql($"Host={host};Database={database};Username={name};Password={password};")
                        .UseInternalServiceProvider(sp));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BlogContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            DbInitializer.Initialize(context);
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}