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

namespace coreTutorials.Controllers
{
    [Route("api/[controller]")]
    [ValidateAntiForgeryToken]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IAntiforgery _antiforgery;
        public UsersController(MyDbContext context, IAntiforgery antiforgery)
        {
            _context = context;
            _antiforgery = antiforgery;
        }

        // GET: api/Users
        [HttpGet]
        public Dto GetUsers()
        {
             _antiforgery.ValidateRequestAsync(HttpContext);
            //StringValues xsrfToken;
            //bool trydata = HttpContext.Request.Headers.TryGetValue("x-xsrf-token-header", out xsrfToken);
            //    //.SingleOrDefault(header => header.Key.Equals("X-XSRF-TOKEN"));
            //var token = _antiforgery.GetAndStoreTokens(HttpContext);
            //if (token.RequestToken == xsrfToken.FirstOrDefault())
            //{
            //    return new Dto { Items = _context.Users, Count = _context.Users.Count() };

            //}
            //Response.Headers.Add("Content-Type", "application/json");

            return new Dto { Items = _context.Users, Count = _context.Users.Count() };
        }
        //[HttpGet("{top}")]
        //public IEnumerable<User> GetUsers(int top)
        //{
        //    return _context.Users.Take(top).ToList();
        //}

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] long id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        public class Dto
        {
            public IEnumerable<User> Items { get; set; }
            public long Count { get; set; }

        }
    }


}