using Microsoft.AspNetCore.Connections;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acount.api.Context
{
    public class MongoClientFactory: MongoClient
    {
        public MongoClientFactory():base(connectionString: ConnectionFactory())
        {

        }

        private static string ConnectionFactory()
        {
            string connectionString;

            if (string.IsNullOrEmpty(Program.DataBaseUser))
            {
                connectionString = $"mongodb://{Program.DataBaseHost}:{Program.DataBasePort}/?readPreference=primary&appname=postal.code.api&ssl=false";
            }
            else
            {
                connectionString = $"mongodb://{Program.DataBaseUser}:{Program.DataBasePws}@{Program.DataBaseHost}:{Program.DataBasePort}/?authSource={Program.DataBaseAuth}&readPreference=primary&appname=account.api&ssl=false&connecttimeout=30000&maxpoolsize=1800&waitQueueSize=20000&waitQueueTimeout=5m";
            }

            //return @"mongodb+srv://atlasUser:itsgallus@cluster0.2c2wj.mongodb.net/admin?authSource=admin&replicaSet=atlas-l8d564-shard-0&readPreference=primary&appname=MongoDB%20Compass&ssl=true";
            return connectionString;
        }
    }
}
