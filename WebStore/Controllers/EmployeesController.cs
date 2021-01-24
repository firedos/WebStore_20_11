using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        public static readonly List<Employee> __Employees = new List<Employee>
        {
            new Employee{ Id = 1, SurName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 39 },
            new Employee{ Id = 2, SurName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 19 },
            new Employee{ Id = 3, SurName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 22 },
        };
        public IActionResult Index() => View(__Employees);

        /// <summary>карточка отдельного сотрудника</summary>
        /// <returns></returns>
        public IActionResult Details(int Id)
        {
            var employees = __Employees.FirstOrDefault(e => e.Id == Id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }
    }
}
