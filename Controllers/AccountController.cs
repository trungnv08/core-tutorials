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
using MongoDB.Driver;

namespace coreTutorials.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly MongoDbContext _dbContext;
        public AccountController(MongoDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var users = _dbContext.Users.Find(item => true).ToList();
            return View(users);
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(Users user)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", user);
            }
            _dbContext.Users.InsertOne(user);
            TempData["notice"] = "User successfully created";
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            var isLoggedIn = SessionHelpers.GetObject<bool>(HttpContext.Session, "_isLogedin");
            if (isLoggedIn)
            {
                //clear count
                SessionHelpers.SetObject<int>(HttpContext.Session, "login_failed", 0);
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    ReturnUrl = "/";
                }
                return Redirect($"{ReturnUrl}");
            }
            var count = SessionHelpers.GetObject<int>(HttpContext.Session, "login_failed");
            if (count > 3)
            {
                return View();
                //return acess denied
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Users user, string ReturnUrl)
        {

            if (IsAuthenticated(user))
            {

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddMinutes(30).ToString()),
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
                SessionHelpers.SetObject<bool>(HttpContext.Session, "_isLogedin", true);
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    ReturnUrl = "/Account";
                }
                return Redirect($"{ReturnUrl}");
            }
            var count = SessionHelpers.GetObject<int>(HttpContext.Session, "login_failed");
            count += 1;
            SessionHelpers.SetObject<int>(HttpContext.Session, "login_failed", count);

            return Redirect("/Account/Login");
        }

        [HttpGet]
        [ActionName("signout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme);
            //clear session
            HttpContext.Session.Clear();
           // SessionHelpers.SetObject<bool>(HttpContext.Session, "_isLogedin", false);
            return Redirect("/Account/Login");
        }
        [Authorize]
        [ActionName("/Users")]
        public JsonResult Users()
        {
            int top = 10;
            var users = _dbContext.Users.Find(item => true).ToEnumerable();
            return Json(users);
        }

        private bool IsAuthenticated(Users user)
        {
            bool result = false;
            var tmp = _dbContext.Users.Find(us => us.Username == user.Username && us.Password == user.Password).FirstOrDefault();
            if (tmp != null)
            {
                result = true;
            }
            return result;
        }

        #region EF core
        //private readonly MyDbContext dbContext;
        //public AccountController(MyDbContext context)
        //{
        //    dbContext = context;
        //}
        //public IActionResult Index()
        //{
        //    var users = dbContext.Users.ToList();
        //    return View(users);
        //}
        //[AllowAnonymous]
        //public IActionResult Login(string ReturnUrl)
        //{
        //    var count = SessionHelpers.getObject<int>(HttpContext.Session, "login_failed");
        //    if (count > 3)
        //    {
        //        return View();
        //        //return acess denied
        //    }
        //    ViewBag.ReturnUrl = ReturnUrl;
        //    return View();
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login(Users user, string returnUrl)
        //{

        //    if (IsAuthenticated(user))
        //    {

        //        List<Claim> claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.Username),
        //            new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddMinutes(30).ToString()),
        //            new Claim(ClaimTypes.Email, user.Username)
        //        };

        //        // create identity
        //        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //        // create principal
        //        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

        //        // write to cookie
        //        await HttpContext.SignInAsync(
        //                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
        //                principal: principal,
        //                properties: new AuthenticationProperties
        //                {
        //                    //IsPersistent = true, // for 'remember me' feature
        //                    //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
        //                });

        //        return Redirect("/Manager");
        //    }
        //    var count = SessionHelpers.getObject<int>(HttpContext.Session, "login_failed");
        //    count += 1;
        //    SessionHelpers.SetObject<int>(HttpContext.Session, "login_failed", count);

        //    return Redirect("/Account/Login");
        //}

        //[HttpGet]
        //[ActionName("signout")]
        //public async Task<IActionResult> LogOut()
        //{
        //    await HttpContext.SignOutAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme);
        //    return Redirect("/Account/Login");
        //}
        //[Authorize]
        //[ActionName("/Users")]
        //public JsonResult Users()
        //{
        //    int top = 10;
        //    var users = dbContext.Users.Take(top).ToList();
        //    return Json(users);
        //}












        //private bool IsAuthenticated(Users user)
        //{
        //    bool result = false;
        //   // var tmp = _dbContext.Users.Find(us => us.Username == user.Username && us.Password == user.Password && us.IsActive == true).FirstOrDefault();
        //     var tmp = dbContext.Users.SingleOrDefault<Users>(us => us.Username == user.Username && us.Password == user.Password && us.IsActive == true);
        //    if (tmp != null)
        //    {
        //        result = true;
        //    }
        //    return result;
        //}
        #endregion



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