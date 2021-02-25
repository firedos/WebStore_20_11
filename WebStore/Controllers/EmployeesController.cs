using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Controllers
{
    //[Route("users")]
    public class EmployeesController : Controller
    {
        //[Route("employees")]
        public IActionResult Index() => View(TestData.Employees);

        //[Route("employee/{id}")]
        /// <summary>карточка отдельного сотрудника</summary>
        /// <returns></returns>
        public IActionResult Details(int Id)
        {
            var employees = TestData.Employees.FirstOrDefault(e => e.Id == Id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }
    }
}
