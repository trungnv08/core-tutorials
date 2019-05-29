using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreTutorials.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
       public IActionResult Products()
        {
            return View();
        }
    }
}