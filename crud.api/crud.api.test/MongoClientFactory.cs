using MongoDB.Driver;

namespace city.test
{
    public class MongoClientFactory: MongoClient
    {
        public MongoClientFactory():base(connectionString: ConnectionFactory())
        {

        }

        private static string ConnectionFactory()
        {
            string connectionString;

             connectionString = $"mongodb+srv://atlasUser:itsgallus@cluster0.2c2wj.mongodb.net/city?retryWrites=true&w=majority";
            // connectionString = $"mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false";

            return connectionString;
        }
    }
}
