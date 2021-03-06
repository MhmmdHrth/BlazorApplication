using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Services.Employee
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeManagement.Models.Employee>> GetEmployees();
        Task<EmployeeManagement.Models.Employee> GetEmployee(int id);
        Task<EmployeeManagement.Models.Employee> UpdateEmployee(int id, EmployeeVM data);
    }
}
