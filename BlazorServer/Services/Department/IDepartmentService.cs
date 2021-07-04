using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Services.Employee
{
    public interface IDepartmentService
    {
        Task<IEnumerable<EmployeeManagement.Models.Department>> GetDepartments();
        Task<EmployeeManagement.Models.Department> GetDepartment(int id);
    }
}
