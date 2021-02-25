using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// сервис управления сотрудниками
    /// </summary>
    interface IEmployeesData
    {
        /// <summary>
        ///  Получение всех сотрудников
        /// </summary>
        IEnumerable<Employee> GetAll();

        /// Получение сотрудников по идентификатору
        Employee GetById(int id);
        
        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="Employee"></param>
        void Add(Employee Employee);

        /// <summary>
        /// Редактирование по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        void Edit(int id, Employee employee);

        /// <summary>
        /// Удаление по id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        void SaveChange()

    }
}
