using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using acount.api.Context;
using city.core.entities;
using city.core.repositories;
using crud.api.core.mappers;
using crud.api.core.repositories;
using crud.api.core.services;
using crud.api.dto.Mapper;
using crud.api.dto.Person;
using crud.api.register.entities.registers;
using crud.api.register.repositories.registers;
using crud.api.register.services.registers;
using data.provider.core;
using data.provider.core.mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace acount.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Program.Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            #region Assembly Info
            services.AddControllers();

            var assembly = GetType().Assembly;
            var assemblyInfo = assembly.GetName();

            var descriptionAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                 .OfType<AssemblyDescriptionAttribute>()
                 .FirstOrDefault();
            var productAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyProductAttribute), false)
                 .OfType<AssemblyProductAttribute>()
                 .FirstOrDefault();
            var copyrightAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)
                 .OfType<AssemblyCopyrightAttribute>()
                 .FirstOrDefault();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = productAttribute.Product,
                        Version = assemblyInfo.Version.ToString(),
                        Description = descriptionAttribute.Description,
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = copyrightAttribute.Copyright,
                            Url = new Uri(@"https://github.com/willimar/crud.api"),
                            Email = "willimar in the gmail",
                        },
                        TermsOfService = null,
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "GNU GENERAL PUBLIC LICENSE",
                            Url = new Uri(@"https://github.com/willimar/crud.api/blob/master/LICENSE")
                        }
                    });
                c.EnableAnnotations();
            });

            services.AddCors(options => {
                options.AddPolicy(Program.AllowSpecificOrigins,
                    builder => {
                        //builder.SetIsOriginAllowed(oringin => {
                        //    return oringin.Contains(@"https://localhost:5001") ||
                        //           oringin.Contains(@"https://localhost:5051") ||
                        //           oringin.Contains(@"http://localhost:4200") ||
                        //           oringin.Contains(@"https://willimar.netlify.app");
                        //})
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            #region Dependences

            services.AddTransient<IMongoClient, MongoClientFactory>();
            services.AddTransient<IDataProvider, DataProvider>(x =>
                new DataProvider(new MongoClientFactory(), Program.DataBaseName)
            );

            #region Repositories

            services.AddScoped<IRepository<City>, CityRepository>();
            services.AddScoped<IRepository<Person>, PersonRepository>();

            #endregion

            #region Mappers

            services.AddScoped<PersonModelMapper>();
            services.AddScoped(sp => new MapperProfile<PersonModel, Person>((PersonModelMapper)sp.GetService(typeof(PersonModelMapper))));

            #endregion

            #region Services

            services.AddScoped<IService<Person>, PersonService>();

            #endregion

            #region GraphQL



            #endregion
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOptions();
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
                app.UseHsts();
            }

            Program.PostalCodeApi = new Uri(Program.Configuration.ReadConfig<string>("Program", "PostalCodeApi"));
                        
            app.UseSwagger();

            #region Assembly Info
            var assembly = GetType().Assembly;
            var productAttribute = assembly
                 .GetCustomAttributes(typeof(AssemblyProductAttribute), false)
                 .OfType<AssemblyProductAttribute>()
                 .FirstOrDefault();
            var assemblyInfo = assembly.GetName();
            #endregion

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    $"{productAttribute.Product} v{assemblyInfo.Version}");

            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(Program.AllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
        }
    }
}
