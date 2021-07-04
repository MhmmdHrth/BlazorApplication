using BlazorServer.Services.Employee;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Pages.BaseClass.EmployeeBC
{
    public class Edit : ComponentBase
    {
        [Inject]
        protected IEmployeeService employeeService { get; set; }

        [Inject]
        protected IDepartmentService departmentService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<Department> Departments { get; set; } = new List<Department>();

        protected override async Task OnInitializedAsync()
        {
            Employee = await employeeService.GetEmployee(Int32.Parse(Id));
            Departments = (await departmentService.GetDepartments()).ToList(); 
        }
    }
}
