using Bookstore.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.DataLayer
{
    public class EmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> emplyees = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Employees";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Employee emp = new Employee();
                    emp.id = sqlDataReader.GetInt32(0);
                    emp.username = sqlDataReader.GetString(6);
                    emp.password = sqlDataReader.GetString(7);
                    emplyees.Add(emp);
                }
            }
            return emplyees;
        }

        public int InsertEmployee(Employee e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO Employees VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                    e.name, e.surname, e.birth_date, e.phone, e.email, e.username, e.password);
                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
