using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coreTutorials.DAL;
using coreTutorials.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.Extensions.Primitives;
using MongoDB.Driver;

namespace coreTutorials.Controllers
{
    [Route("api/[controller]")]
    //[ValidateAntiForgeryToken]
    //[ValidateAntiForgeryToken]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MongoDbContext _dbContext;
        //private readonly MyDbContext _context;
        //private readonly IAntiforgery _antiforgery;
        public UsersController(MongoDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/Users
        [HttpPost]
        public Dto GetUsers()
        {


            var data = new Dto { result = _dbContext.Users.Find(user => true).ToEnumerable() };
            data.count = data.result.Count();

            return data;

        }


        // POST: api/Users
        [HttpPost]
        [Route("/add")]
        public void PostUser([FromBody] Users user)
        {

            _dbContext.Users.InsertOne(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void DeleteUser([FromRoute] long id)
        {

        }

        //private bool UserExists(long id)
        //{
        //    return _context.Users.Any(e => e.UserId == id);
        //}
        public class Dto
        {
            public IEnumerable<Users> result { get; set; }
            public long count { get; set; }
            public string _xsrf_token { get; set; }

        }
    }


}