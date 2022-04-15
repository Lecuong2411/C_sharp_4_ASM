using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Lab1_2
{
    public class Startup
    {
        private readonly List<string> _a;
        public readonly IConfiguration _Iconfiguration;

        public Startup(IConfiguration configuration)
        {
            _Iconfiguration = configuration;
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
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<div> Bai 1</div>");
                await next.Invoke();
                await context.Response.WriteAsync("<br>");
                await context.Response.WriteAsync("<div>Ket Thuc Bai 1 </div>");


            });


            app.Run(async (context) =>
                {
                    string path = "";
                    string texts = File.ReadAllText(path);
                    dynamic d = JObject.Parse(texts);//parse từ file sang oject
                var items = (JArray)d.Sinhvien;
                //tạo model


                await context.Response.WriteAsync("Nhung sinh vien ten co chu a , tuoi tren 20 va song tai Ha Noi la : ");
                    var a = _Iconfiguration.GetSection("Sinhvien").GetChildren();
                    foreach (IConfigurationSection section in a.Where(c => c.GetValue<string>("Name").ToLower().Contains("a") && c.GetValue<int>("Age") > 20 && c.GetValue<string>("Address").ToLower().Contains("ha noi")))
                    {

                        var name = section.GetValue<string>("Name");
                        var age = section.GetValue<int>("Age");
                        var address = section.GetValue<string>("Address");
                        await context.Response.WriteAsync(name + " ");
                        await context.Response.WriteAsync(Convert.ToString(age) + " Tuoi ");
                        await context.Response.WriteAsync(address + " ");
                        await context.Response.WriteAsync("<br>");
                    }
                    await context.Response.WriteAsync("<br>");
                    await context.Response.WriteAsync(" Nhung nhom sinh vien co tuoi cach nhau khong qua 2 : ");
                    await context.Response.WriteAsync("<br>");


                    int i = 0;
                    int k = 1;
                    foreach (IConfigurationSection x in a.OrderBy(c => c.GetValue<int>("Age")))
                    {
                        var n = x.GetValue<int>("Age");
                        var b = x.GetValue<string>("Name");
                        if (n - 2 > i)
                        {
                            await context.Response.WriteAsync($"Nhom {k} : ");
                            k++;
                            await context.Response.WriteAsync("<br>");
                        }
                        await context.Response.WriteAsync(b + " ");
                        await context.Response.WriteAsync(n + " Tuoi ");
                        await context.Response.WriteAsync("<br>");

                        i = n;


                    }




                });

        }
  
    }
}
