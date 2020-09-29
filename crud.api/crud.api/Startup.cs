using city.core.entities;
using city.core.repositories;
using crud.api.Context;
using crud.api.core.fieldType;
using crud.api.core.mappers;
using crud.api.core.repositories;
using crud.api.core.services;
using crud.api.dto.Person;
using crud.api.GraphQL.Queries;
using crud.api.GraphQL.Queries.InternalQueries;
using crud.api.GraphQL.Types;
using crud.api.Mapper;
using crud.api.register.entities.registers;
using crud.api.register.entities.registers.relational;
using crud.api.register.repositories.registers;
using crud.api.register.services.registers;
using data.provider.core;
using data.provider.core.mongo;
using graph.simplify.core;
using GraphQL.Server;
using GraphQL.Server.Internal;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Reflection;

namespace crud.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Program.Configuration = configuration;
        }

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

            services.AddScoped<IMongoClient, MongoClientFactory>();

            services.AddScoped<IDataProvider, DataProvider>(x =>
                new DataProvider(new MongoClientFactory(), Program.DataBaseName)
            );

            #region Repositories

            services.AddScoped<IRepository<City>, CityRepository>();
            //services.AddScoped<IRepository<Person>, PersonRepository>();
            services.AddScoped<IRepository<PersonDocument>, BaseRepository<PersonDocument>>();
            services.AddScoped<IRepository<PersonContact>, BaseRepository<PersonContact>>();
            services.AddScoped<IRepository<PersonAddress>, BaseRepository<PersonAddress>>();

            #endregion

            #region Mappers

            //services.AddScoped<PersonModelMapper>();
            //services.AddScoped<PersonMapper>();

            //services.AddScoped(sp => new MapperProfile<PersonInfoModel, Person>((PersonModelMapper)sp.GetService(typeof(PersonModelMapper))));
            //services.AddScoped(sp => new MapperProfile<Person, Person>((PersonMapper)sp.GetService(typeof(PersonMapper))));
            //services.AddScoped(sp => new MapperProfile<UserModel, Person>((PersonMapper)sp.GetService(typeof(PersonMapper))));

            #endregion

            #region Services

            //services.AddScoped<IService<Person>, PersonService>();

            services.AddScoped<IService<PersonDocument>, BaseService<PersonDocument>>();
            services.AddScoped<IService<PersonContact>, BaseService<PersonContact>>();
            services.AddScoped<IService<PersonAddress>, BaseService<PersonAddress>>();

            #endregion

            #region GraphQL
            StartupResolve.ConfigureServices(services);
            services.AddScoped<IGraphQLExecuter<AppScheme<MacroQuery>>, DefaultGraphQLExecuter<AppScheme<MacroQuery>>>();

            services.AddScoped<MacroQuery>();
            services.AddScoped<PersonQuery>();

            services.AddScoped<DictionaryFieldType>();
            services.AddScoped<DictionaryMessageType>();
            services.AddScoped<PersonType>();
            services.AddScoped<CityType>();
            services.AddScoped<StateType>();
            services.AddScoped<CountryType>();
            services.AddScoped<GuidGraphType>();

            services.AddScoped<AppScheme<MacroQuery>>();

            services.AddScoped<EnumerationGraphType<RecordStatus>>();
            services.AddScoped<ListGraphType<DictionaryMessageType>>();
            services.AddScoped<ListGraphType<DictionaryFieldType>>();
            services.AddScoped<ListGraphType<PersonType>>();
            #endregion
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOptions();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
            }
            else
            {
                app.UseHsts();
            }

            Program.PostalCodeApi = new Uri(Program.Configuration.ReadConfig<string>("Program", "PostalCodeApi"));

            app.UseDeveloperExceptionPage();
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

            #region GraphQL Setup
            app.UseGraphQL<AppScheme<MacroQuery>>();
            StartupResolve.Configure(app);
            #endregion          
        }
    }
}