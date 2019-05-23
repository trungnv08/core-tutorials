using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using coreTutorials.DAL;
using coreTutorials.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coreTutorials.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly MyDbContext dbContext;

        public AccountController(MyDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            var users = dbContext.Users.ToList();
            return View(users);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            var count = SessionHelpers.getObject<int>(HttpContext.Session, "login_failed");
            if (count > 3)
            {
                return View();
                //return acess denied
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (IsAuthenticated(user))
            {

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddSeconds(30).ToString()),
                    new Claim(ClaimTypes.Email, user.Username)
                };

                // create identity
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // create principal
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                // write to cookie
                await HttpContext.SignInAsync(
                        scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                        principal: principal,
                        properties: new AuthenticationProperties
                        {
                            //IsPersistent = true, // for 'remember me' feature
                            //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                        });

                return Redirect("/Account");
            }
            var count = SessionHelpers.getObject<int>(HttpContext.Session, "login_failed");
            count += 1;
            SessionHelpers.SetObject<int>(HttpContext.Session, "login_failed", count);

            return Redirect("/Account/Login");
        }

        [HttpGet]
        [ActionName("signout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
        [Authorize]
        [ActionName("/Users")]        
        public JsonResult Users()
        {
            int top = 10;
            var users = dbContext.Users.Take(top).ToList();
            return Json(users);
        }












        private bool IsAuthenticated(User user)
        {
            bool result = false;
            var tmp = dbContext.Users.SingleOrDefault<User>(us => us.Username == user.Username && us.Password == user.Password && us.IsActive == true);
            if (tmp != null)
            {
                result = true;
            }
            return result;
        }




        public class SessionModel
        {
            public string SessionKeyName = "_Name";
            public string SessionKeyUsername = "_Username";
            public string SessionKeyStatus = "_IsActive";
            public string SessionKeyLoginCount = "_Count";
            public string SessionName { get; private set; }
            public string SessionUsername { get; private set; }
            public string SessionStatus { get; private set; }
            public string SessionLoginCount { get; private set; }

        }
    }

}