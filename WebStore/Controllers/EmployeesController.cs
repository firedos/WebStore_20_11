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
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData employeesData) => _EmployeesData = employeesData;

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

        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new Employee());
            if (id < 0) return BadRequest();
            var employee = _EmployeesData.GetById((int)id);
            if (employee is null) return NotFound();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View(new Employee());
        }

        

        [HttpPost]
        public IActionResult Create(Employee employee)
        {  
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));
            
            //проверяем что с моделью все впорядке
            if (!ModelState.IsValid) return View(employee);

            _EmployeesData.Add(employee);
            _EmployeesData.SaveChange();
            return RedirectToAction("Index");
        }

        [HttpPost]
        /// <summary>
        /// Ответная часть по кнопке Сохранить из формы 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public IActionResult Edit(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            //проверяем что с моделью все впорядке
            if (!ModelState.IsValid) return View(employee);

            var id = employee.Id;
            if (id == 0) _EmployeesData.Add(employee);
            else
                _EmployeesData.Edit(id, employee);

            _EmployeesData.SaveChange();
            return RedirectToAction("Index");
        }
    }
}
