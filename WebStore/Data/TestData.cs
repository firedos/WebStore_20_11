using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Data
{
    public class TestData
    {

        public static List<Employee> Employees { get; } = new List<Employee>
        {
            new Employee{ Id = 1, SurName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", Age = 39 },
            new Employee{ Id = 2, SurName = "Петров", FirstName = "Петр", Patronymic = "Петрович", Age = 19 },
            new Employee{ Id = 3, SurName = "Сидоров", FirstName = "Сидр", Patronymic = "Сидорович", Age = 22 },
        };
    }
}
