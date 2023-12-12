using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FilmStoreDBContext
    {
        const string connectionUri = "mongodb://localhost:27017";
        public IMongoClient _mongoClient { get; set; }
        public FilmStoreDBContext()
        {
            _mongoClient = new MongoClient(connectionUri);
        }

        public IMongoClient GetMongoDbContext()
        {
            return _mongoClient;
        }
    }
}
