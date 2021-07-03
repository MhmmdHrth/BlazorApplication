using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class DepartmentRepo : IDepartment
    {
        private readonly AppDbContext dbContext;

        public DepartmentRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Department> GetDepartment(int Id)
        {
            var result = await dbContext.Departments.FirstOrDefaultAsync(x => x.Id == Id);
            if(result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var result = await dbContext.Departments.ToListAsync();

            if(result != null)
            {
                return result;
            }

            return null;
        }
    }
}
