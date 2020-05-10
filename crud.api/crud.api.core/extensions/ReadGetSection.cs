using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.core.extensions
{
    public static class ReadGetSection
    {
        public static TCast ReadConfig<TCast>(this IConfiguration configuration, string fullPath, string fieldName)
        {
            var section = configuration.GetSection(fullPath).GetSection(fieldName);

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
