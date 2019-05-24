using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreTutorials.DAL;
using coreTutorials.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreTutorials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateAntiForgeryToken]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        public CategoriesController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public Dto GetCategories()
        {
            var data = new Dto
            {
                Result = _dbContext.Categories,
                Count = _dbContext.Categories.Count()
            };
            return data;
        }











        public class Dto
        {
            public IEnumerable<Category> Result { get; set; }
            public long Count { get; set; }
            public string _xsrf_token { get; set; }

        }
    }
}