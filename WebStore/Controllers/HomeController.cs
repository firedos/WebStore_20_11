using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public static readonly List<Employee> __Employees = new List<Employee>
        {
            new Employee{ Id = 1, SurName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 39 },
            new Employee{ Id = 2, SurName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 19 },
            new Employee{ Id = 3, SurName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 22 },
        };
        public IActionResult Index()
        {
            //return View("22222222");
            //return Content("Номе controller - action index");
            return View();
        }
        public IActionResult SomeAction()
        {
            //return Content("Номе controller - action SomeAction");
            return View();
        }

        public IActionResult Employees()
        {
            return View(__Employees);
        }

        /// <summary>карточка отдельного сотрудника</summary>
        /// <returns></returns>
        public IActionResult Employee(int Id)
        {
            var employees = __Employees.FirstOrDefault(e => e.Id == Id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
            
        }

        public IActionResult Error404() => View();

        public IActionResult Blog() => View();
        
        public IActionResult BlogSingl() => View();
        
        public IActionResult Cart() => View();
        
        public IActionResult CheckOut() => View();

        public IActionResult ContactUs() => View();

        public IActionResult Login() => View();

        public IActionResult Shop() => View();

        public IActionResult ProductDetails() => View();

    }
}
