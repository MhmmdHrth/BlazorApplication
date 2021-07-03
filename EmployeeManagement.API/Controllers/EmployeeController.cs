using EmployeeManagement.API.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employeeRepo;

        public EmployeeController(IEmployee employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }


        [HttpGet(nameof(GetEmployees))]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepo.GetEmployees());
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{err.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var obj = await employeeRepo.GetEmployee(id);
                return obj == null ? NotFound() : Ok(obj);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{err.Message}");
            } 
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(EmployeeVM employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                var obj = await employeeRepo.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new {id = obj.Id }, obj);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{err.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, EmployeeVM employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest();
                }

                var obj = await employeeRepo.GetEmployee(id);
                return obj == null ? NotFound() : Ok(await employeeRepo.UpdateEmployee(id,employee));
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{err.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployees(int id)
        {
            try
            {
                var obj = await employeeRepo.GetEmployee(id);
                return obj == null ? NotFound() : Ok(await employeeRepo.DeleteEmployee(id));
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{err.Message}");
            }
        }
    }
}
