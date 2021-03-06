using AutoMapper;
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

        [Inject]
        protected IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public EmployeeVM EmployeeVM { get; set; } = new EmployeeVM();
        public List<Department> Departments { get; set; } = new List<Department>();
        public bool btnLoading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await employeeService.GetEmployee(Int32.Parse(Id));
            Departments = (await departmentService.GetDepartments()).ToList();

            Mapper.Map<Employee,EmployeeVM>(Employee, EmployeeVM);
        }

        protected async Task Submit()
        {
            try
            {
                this.btnLoading = true;

                await employeeService.UpdateEmployee(Int32.Parse(Id), EmployeeVM);
                NavigationManager.NavigateTo("/");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                this.btnLoading = false;
            }
        }
    }
}
