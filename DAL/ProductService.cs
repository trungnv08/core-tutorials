using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using coreTutorials.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
namespace coreTutorials.DAL
{
    public class ProductService
    {
        public readonly IMongoCollection<Product> _products;
        public ProductService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("mongoDB"));
            var database = client.GetDatabase("core-mvc");
            _products = database.GetCollection<Product>("Product");

        }

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }
        public Product GetProduct(long Id)
        {
            return _products.Find<Product>(item => item.ProductId == Id).FirstOrDefault<Product>();

        }
    }
}
