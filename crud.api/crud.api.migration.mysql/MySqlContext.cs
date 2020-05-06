using crudi.api.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace crud.api.migration.mysql
{
    public class MySqlContext: DataContext
    {
        private static DbContextOptions GetOptions()
        {
            var port = 0;

            var ip = "localhost";
            var dataBaseName = "data_provider";
            var password = "!sql2020";
            var userName = "root";

            const string CONNECTIONSTRING = @"Server={0}{4};Database={1};Uid={2};Pwd={3};";
            var builder = new DbContextOptionsBuilder();
            var connectionString = string.Format(CONNECTIONSTRING, ip, dataBaseName, userName, password,
                    port > 0 ? $";Port={port.ToString()}" : string.Empty);
            builder.UseMySql(connectionString);

            return builder.Options;
        }

        public MySqlContext() : base(GetOptions())
        {

        }
    }
}
