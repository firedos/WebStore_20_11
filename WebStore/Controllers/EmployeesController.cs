using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    //[Route("users")]
    class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData employeesData)
        {
            _EmployeesData = employeesData;
        }

        //[Route("employees")]
        public IActionResult Index() => View(_EmployeesData.GetAll());

        //[Route("employee/{id}")]
        /// <summary>карточка отдельного сотрудника</summary>
        /// <returns></returns>
        public IActionResult Details(int Id)
        {
            //var employees = TestData.Employees.FirstOrDefault(e => e.Id == Id);
            var employees = _EmployeesData.GetById(Id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }
    }
}
