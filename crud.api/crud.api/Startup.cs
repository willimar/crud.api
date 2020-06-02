using crud.api.core.mappers;
using crud.api.core.repositories;
using crud.api.core.services;
using crud.api.Mapper;
using crud.api.migration.mysql;
using crud.api.Model.Registers;
using crud.api.register.entities.registers;
using crud.api.register.entities.registers.relational;
using crud.api.register.repositories.registers;
using crud.api.register.services.registers;
using crudi.api.context;
using data.provider.core;
using data.provider.core.mysql;
using extension.facilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace crud.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static List<Task> taskList;
        private static Task taskControl;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
                        builder.SetIsOriginAllowed(oringin => {
                            return oringin.Contains(@"https://localhost:5001") || 
                                   oringin.Contains(@"https://willimar.netlify.app");
                        })
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            #region Dependences

            services.AddScoped(r => GetDbOptions());
            services.AddScoped<DbContext>(r => new DataContext((DbContextOptions)r.GetService(typeof(DbContextOptions))));
            services.AddScoped<IDataProvider, DataProvider>();

            #region Repositories

            services.AddScoped<IRepository<City>, CityRepository>();
            services.AddScoped<IRepository<Person>, PersonRepository > ();
            services.AddScoped<IRepository<PersonDocument>, BaseRepository<PersonDocument>>();
            services.AddScoped<IRepository<PersonContact>, BaseRepository<PersonContact>>();
            services.AddScoped<IRepository<PersonAddress>, BaseRepository<PersonAddress>>();
            services.AddScoped<IRepository<PersonMessage>, BaseRepository<PersonMessage>>();
            services.AddScoped<IRepository<PersonType>, BaseRepository<PersonType>>();

            #endregion

            #region Mappers

            services.AddScoped<PersonModelMapper>();
            services.AddScoped<PersonMapper>();

            services.AddScoped(sp => new MapperProfile<PersonModel, Person>((PersonModelMapper)sp.GetService(typeof(PersonModelMapper))));
            services.AddScoped(sp => new MapperProfile<Person, Person>((PersonMapper)sp.GetService(typeof(PersonMapper))));

            #endregion

            #region Services

            services.AddScoped<IService<Person>, PersonService>();

            services.AddScoped<IService<PersonDocument>, BaseService<PersonDocument>>();
            services.AddScoped<IService<PersonContact>, BaseService<PersonContact>>();
            services.AddScoped<IService<PersonAddress>, BaseService<PersonAddress>>();
            services.AddScoped<IService<PersonMessage>, BaseService<PersonMessage>>();
            services.AddScoped<IService<PersonType>, BaseService<PersonType>>();

            #endregion

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddOptions();
        }

        private DbContextOptions GetDbOptions()
        {
            var port = this.Configuration.ReadConfig<int>("MySql", "Port");

            var ip = this.Configuration.ReadConfig<string>("MySql", "Host");
            var dataBaseName = this.Configuration.ReadConfig<string>("MySql", "DataBase");

            var passPhrase = "fodão";

            var cipherTextPass = this.Configuration.ReadConfig<string>("MySql", "Pws");
            var cipherTextUser = this.Configuration.ReadConfig<string>("MySql", "User");
            var password = mc.cript.Cryptographer.Decrypt(cipherTextPass, passPhrase);
            var userName = mc.cript.Cryptographer.Decrypt(cipherTextUser, passPhrase);

            const string CONNECTIONSTRING = @"Server={0}{4};Database={1};Uid={2};Pwd={3};";

            var builder = new DbContextOptionsBuilder();
            
            var connectionString = string.Format(CONNECTIONSTRING, ip, dataBaseName, userName, password,
                    port > 0 ? $";Port={port}" : string.Empty);

            builder.UseLazyLoadingProxies().UseMySql(connectionString);

            return builder.Options;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
            }
            else
            {
                app.UseHsts();
            }

            Program.PostalCodeApi = new Uri(this.Configuration.ReadConfig<string>("Program", "PostalCodeApi"));

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
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

            taskList = new List<Task>()
            {
                Task.Run(() => app.MigrationExec(this.GetDbOptions()) )
            };

            taskControl = Task.Run(() => {
                while (taskList.Any())
                {
                    taskList.ForEach(item => {
                        if (item?.Status == TaskStatus.RanToCompletion)
                        {
                            item.Dispose();
                        }
                    });

                    taskList.RemoveAll(t => t == null || t.Status == TaskStatus.RanToCompletion);
                    Task.Delay(5000);
                }
                Task.Delay(1000);
            });            
        }
    }
}
