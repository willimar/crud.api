using crudi.api.context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace crud.api.migration.mysql
{
    public static class MigrationTool
    {
        public static void MigrationExec(this IApplicationBuilder app, DbContextOptions options)
        {
            using (var context = new MySqlMigration(options))
            {
                context.Database.Migrate();
            }
        }
    }

    public class MySqlMigration: DataContext
    {
        private static DbContextOptions GetOptions()
        {
            var port = 3306;

            var ip = "db4free.net";
            var dataBaseName = "crudapi";
            var password = "itsgallus";
            var userName = "willimar";

            const string CONNECTIONSTRING = @"Server={0}{4};Database={1};Uid={2};Pwd={3};";
            var builder = new DbContextOptionsBuilder();
            var connectionString = string.Format(CONNECTIONSTRING, ip, dataBaseName, userName, password,
                    port > 0 ? $";Port={port.ToString()}" : string.Empty);
            builder.UseMySql(connectionString);

            return builder.Options;
        }

        public MySqlMigration() : base(GetOptions())
        {

        }

        public MySqlMigration(DbContextOptions options): base(options)
        {

        }
    }
}
