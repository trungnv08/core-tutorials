using coreTutorials.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreTutorials.DAL
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("core-mvc");
        }
        public IMongoCollection<Users> Users { get { return _database.GetCollection<Users>("Users"); } }
        public IMongoCollection<Category> Categories
        {
            get
            {
                return _database.GetCollection<Category>("Categories");
            }
        }
        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("Produtcs");
            }
        }



    }
}
