using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class ApiConfiguration
    {
        /// <summary>
        /// Get Enviroment Variable or if not exists get Appsettings section
        /// </summary>
        /// <typeparam name="TCast">Value to cast</typeparam>
        /// <param name="configuration">IConfiguration from the application</param>
        /// <param name="fullPath">Whether your path has '.' like in "MyConfig.InLocal". In the environment variable you need has "MYCONFIG_INLOCAL_{field}". </param>
        /// <param name="field">To environment variable you will have $"{fullPath}_{field}".ToUpper()</param>
        /// <returns>Return value converted to TCast type.</returns>
        public static TCast ReadConfig<TCast>(this IConfiguration configuration, string fullPath, string field)
        {
            var initial = fullPath.Replace('.', '_');
            var enviroment = string.Empty;
            
            if (string.IsNullOrEmpty(enviroment))
            {
                enviroment = Environment.GetEnvironmentVariable($"{initial}_{field}".ToUpper(), EnvironmentVariableTarget.Machine);
            }

            if (string.IsNullOrEmpty(enviroment))
            {
                enviroment = Environment.GetEnvironmentVariable($"{initial}_{field}".ToUpper(), EnvironmentVariableTarget.User);
            }

            if (string.IsNullOrEmpty(enviroment))
            {
                enviroment = Environment.GetEnvironmentVariable($"{initial}_{field}".ToUpper(), EnvironmentVariableTarget.Process);
            }

            if (string.IsNullOrEmpty(enviroment))
            {
                enviroment = Environment.GetEnvironmentVariable($"{initial}_{field}".ToUpper());
            }


            if (!string.IsNullOrEmpty(enviroment))
            {
                return (TCast)Convert.ChangeType(enviroment, typeof(TCast));
            }

            var section = configuration.GetSection(fullPath).GetSection(field);

            if (string.IsNullOrWhiteSpace(section.Value))
            {
                return default;
            }
            else
            {
                return (TCast)Convert.ChangeType(section.Value, typeof(TCast));
            }
        }
    }
}
