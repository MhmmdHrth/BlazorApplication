using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int Id);
        Task<Employee> AddEmployee(EmployeeVM employee);
        Task<Employee> UpdateEmployee(int id,EmployeeVM employee);
        Task<Employee> DeleteEmployee(int Id);
    }
}
