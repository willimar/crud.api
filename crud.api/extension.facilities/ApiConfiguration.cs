using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class ApiConfiguration
    {
        public static TCast ReadConfig<TCast>(this IConfiguration configuration, string fullPath, string field)
        {
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
