using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace WebStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(); // ƒл€ 2.2
            //services.AddControllersWithViews(); // ƒл€ 3.1 и выше
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            app.UseStaticFiles(); // выдавать файлы и картинки иначе не даст
            app.UseDefaultFiles();
            // подключаем конвеер обработки вх запросов
            // указываем какие файлы вадавать при необходимости
            //app.UseStaticFiles(new StaticFileOptions(new SharedOptions() {})); 
            app.UseRouting();

            app.UseWelcomePage("/welcom");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/greetings", async context =>
                {
                    await context.Response.WriteAsync(Configuration["CustomGreetings"]);
                });

                endpoints.MapControllerRoute(
                    name:       "default",
                    //pattern:    "Home/Index/Id"   // Ёквивалентно LocalHost:5000/Home/Index/id
                    pattern: "{controller=Home}/{action=Index}/{id?}"   // Ёквивалентно LocalHost:5000/Home/Index/id
                );
            });
        }
    }
} 
