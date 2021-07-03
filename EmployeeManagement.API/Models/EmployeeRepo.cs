using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class EmployeeRepo : IEmployee
    {
        private readonly AppDbContext dbContext;

        public EmployeeRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Employee> AddEmployee(EmployeeVM employee)
        {
            var obj = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Gender = employee.Gender,
                DOB = employee.DOB,
                DepartmentId = employee.DepartmentId,
                PhotoPath = employee.PhotoPath,
            };

            var result = await dbContext.Employees.AddAsync(obj);
            await dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int Id)
        {
            var result = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);

            if(result != null)
            {
                dbContext.Remove(result);
                await dbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            var result = await dbContext.Employees.Include(x => x.Department)
                                                  .FirstOrDefaultAsync(x => x.Id == Id);

            if(result != null)
            {
                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var result = await dbContext.Employees.ToListAsync();
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Employee> UpdateEmployee(int id,EmployeeVM employee)
        {
            var obj = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(obj != null)
            {
                obj.FirstName = employee.FirstName;
                obj.LastName = employee.LastName;
                obj.Email = employee.Email;
                obj.DOB = employee.DOB;
                obj.Gender = employee.Gender;
                obj.DepartmentId = employee.DepartmentId;
                obj.PhotoPath = employee.PhotoPath;

                dbContext.Employees.Update(obj);
                await dbContext.SaveChangesAsync();

                return obj;
            }

            return null;
        }
    }
}
