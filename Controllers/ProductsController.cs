using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreTutorials.DAL;
using coreTutorials.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace coreTutorials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   // [ValidateAntiForgeryToken]
    public class ProductsController : ControllerBase
    {
        #region EF core
        //private readonly MyDbContext _dbContext;
        //public ProductsController(MyDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //[HttpPost]
        //public Dto GetProducts()
        //{
        //    var data = new Dto
        //    {
        //        Result = _dbContext.Products,
        //        Count = _dbContext.Products.Count()
        //    };
        //    return data;
        //}

        //[HttpPost("{CategoryId}")]
        //public Dto GetProductsByCategoryId([FromRoute] string CategoryId)
        //{
        //    var result = _dbContext.Products.Where(product => product.Category.CategoryId == CategoryId);
        //    var data = new Dto
        //    {
        //        Result = result,
        //        Count = result.Count()
        //    };
        //    return data;
        //}

        //[HttpPost("update/{productId}")]
        //public Product Update([FromRoute] long productId, [FromForm] Product product)
        //{
        //    var data = _dbContext.Products.Where(item => item.ProductId == product.ProductId).Single();
        //    data.Name = product.Name;
        //    _dbContext.Products.Update(data);
        //    _dbContext.SaveChanges();
        //    return data;
        //}
        //[HttpPost("delete/{productId}")]
        //public bool Remove([FromRoute] string productId)
        //{
        //    var data = _dbContext.Products.Where(item => item.ProductId == productId).Single();
        //    _dbContext.Products.Attach(data);
        //    _dbContext.Remove(data);
        //    _dbContext.SaveChanges();
        //    return true;
        //}
        #endregion

        private readonly MongoDbContext _dbContext;
        public ProductsController(MongoDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public Dto Get()
        {
            return new Dto
            {
                Result = _dbContext.Products.Find(item => true).ToEnumerable(),
                Count = _dbContext.Products.Find(item => true).CountDocuments()
            };
        }
        [HttpPost("{categoryId}")]
        public Dto Get([FromRoute]string categoryId)
        {
            var dto = new Dto
            {
                Result = _dbContext.Products.Find(item => item.CategoryId == categoryId).ToEnumerable()
            };
            dto.Count = dto.Result.Count();
            return dto;

        }
        [HttpPost("info/{productId}")]
        public Dto GetInfo([FromRoute]string productId)
        {
            var dto = new Dto
            {
                Result = _dbContext.Products.Find(item => item.ProductId == productId).ToEnumerable()
            };
            dto.Count = dto.Result.Count();
            return dto;

        }
        [HttpPost("add")]
        public void Create([FromBody]Product product)
        {
            _dbContext.Products.InsertOne(product);

        }
        [HttpPost("update")]
        public string Update([FromBody]Product product)
        {
            var result = _dbContext.Products.ReplaceOne(p => p.ProductId == product.ProductId, product);
            return result.ToJson();
        }
        public class Dto
        {
            public IEnumerable<Product> Result { get; set; }
            public long Count { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string _xsrf_token { get; set; }

        }

    }
}