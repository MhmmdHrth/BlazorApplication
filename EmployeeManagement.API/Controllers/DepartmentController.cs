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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment departmentRepo;

        public DepartmentController(IDepartment departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        [HttpGet(nameof(GetDepartments))]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            try
            {
                return Ok(await departmentRepo.GetDepartments());
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{err.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetEmployee(int id)
        {
            try
            {
                var obj = await departmentRepo.GetDepartment(id);
                return obj == null ? NotFound() : Ok(obj);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{err.Message}");
            }
        }
    }
}
