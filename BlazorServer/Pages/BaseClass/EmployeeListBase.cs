using BlazorServer.Services.Employee;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorServer.Pages.BaseClass
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        private IEmployeeService EmployeeService { get; set; }

        protected IEnumerable<Employee> Employees { get; set; }
        protected bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            await Task.WhenAll(new[]{
                Task.Run(() => this.LoadEmployees()),
                Task.Run(() => this.test()),
            });
        }

        private async Task<IEnumerable<Employee>> LoadEmployees()
        {
            this.isLoading = true;
            Employees = (await this.EmployeeService.GetEmployees()).ToList();
            this.isLoading = false;

            return this.Employees;
        }

        private void test()
        {

        }
    }
}
