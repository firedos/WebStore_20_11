using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View("22222222");
            return Conflict("Номе controller - action index");
        }
        public IActionResult SomeAction()
        {
            return Conflict("Номе controller - action SomeAction");
        }
    }
}
