using Lab_1.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_1.Extensions;

namespace Lab_1
{
    public class Startup
    {
        private readonly IConfiguration _iconfiguration;
        public Startup(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMiddleware<SimpleMiddleware>();
         //   app.UseMiddlewareExtensions();
            app.UseStaticFiles();
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<div> Hello FPoly from the middleware 1 </div>");
                await next.Invoke();
                await context.Response.WriteAsync("<div> Returning from the middleware 1 </div>");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<div> Hello FPoly from the middleware 2 </div>");
                await next.Invoke();
                await context.Response.WriteAsync("<div> Returning from the middleware 2 </div>");
              
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<div> Hello FPoly from the middleware 3 </div>");
                await context.Response.WriteAsync(_iconfiguration.GetSection("book:0:language").Value + " ");
                await context.Response.WriteAsync(_iconfiguration.GetSection("book:0:edition").Value + " ");
                await context.Response.WriteAsync(_iconfiguration.GetSection("book:0:author").Value + " ");
                await context.Response.WriteAsync("<br>");
                await context.Response.WriteAsync(_iconfiguration.GetSection("book:1:language").Value + " ");
                await context.Response.WriteAsync(_iconfiguration.GetSection("book:1:edition").Value + " ");
                await context.Response.WriteAsync(_iconfiguration.GetSection("book:1:author").Value + " ");

            });
           
        }
    }
}
