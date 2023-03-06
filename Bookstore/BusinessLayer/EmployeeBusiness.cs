using Bookstore.DataLayer;
using Bookstore.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BusinessLayer
{
    public class EmployeeBusiness
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeBusiness()
        {
            this.employeeRepository = new EmployeeRepository(); //inicijalizacija objekta
        }
        public bool LoginEmployee(string username, string password)
        {
            List<Employee> employees = this.employeeRepository.GetAllEmployees();
            bool exist = false;
            foreach (Employee e in employees)
            {
                if (e.username==username && e.password==password)
                {
                    exist = true;
                }
            }
            return exist;
        }
        public bool InsertEmployee(Employee e)
        {
            if (this.employeeRepository.InsertEmployee(e) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
