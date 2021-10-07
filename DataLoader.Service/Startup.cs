using DataLoader.DBCore;
using DataLoader.PHDReder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Reflection;

namespace DataLoader.Service
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var settings = new ApplicationSettings();
            services.AddSingleton(typeof(IDBSettings), settings);
            services.AddSingleton(typeof(IReaderSettings), settings);

            services.AddScoped<IDBCoreObjectFactory, DBCoreObjectFactory>();
            services.AddScoped<IReaderObjectFactory>(x => 
            {
                var fact = x.GetRequiredService<IDBCoreObjectFactory>();
                return new ReaderObjectFactory(settings, fact.Resolve<ILogError>());
            });

            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "DataLoader.Service API", Version = "v2" });
                //try
                //{
                //    c.IncludeXmlComments(XmlCommentsFilePath);
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
            });
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v2/swagger.json", "DataLoader.Service API V2");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
