using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int Id);
    }
}
