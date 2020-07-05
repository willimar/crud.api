using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace crud.api
{
    public class Program
    {
        private static object _lock;
        public const string AllowSpecificOrigins = "_AllowSpecificOrigins";
        public static IConfiguration Configuration { get; set; }
        public static string DataBaseHost { get { lock (_lock) { return GetConfig<string>("MongoDb", "Host"); } } }
        public static int DataBasePort { get { lock (_lock) { return GetConfig<int>("MongoDb", "Port"); } } }
        internal static string DataBaseUser { get { lock (_lock) { return "atlasUser"; } } }
        internal static string DataBasePws { get { lock (_lock) { return "itsgallus"; } } }
        public static string DataBaseAuth { get { lock (_lock) { return GetConfig<string>("MongoDb", "Auth"); } } }
        public static string DataBaseName { get { lock (_lock) { return GetConfig<string>("MongoDb", "DataBase"); } } }

        public static Uri PostalCodeApi { get; internal set; }

        internal static TCast GetConfig<TCast>(string sectionName, string fieldName)
        {
            var section = Configuration.GetSection(sectionName).GetSection(fieldName);

            if (string.IsNullOrWhiteSpace(section.Value))
            {
                return default;
            }
            else
            {
                return (TCast)Convert.ChangeType(section.Value, typeof(TCast));
            }
        }

        public static void Main(string[] args)
        {
            _lock = new { id = Guid.NewGuid() };
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
