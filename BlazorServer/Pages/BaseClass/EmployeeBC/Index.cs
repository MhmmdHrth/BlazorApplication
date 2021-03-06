using BlazorServer.Services.Employee;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorServer.Pages.BaseClass.EmployeeBC
{
    public class Index : ComponentBase
    {
        [Inject]
        private IEmployeeService EmployeeService { get; set; }

        protected IEnumerable<Employee> Employees { get; set; }
        protected bool isLoading = false;
        protected bool showFooter  = true;
        public int SelectedEmployeesCount { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            this.isLoading = true;
            Employees = (await this.EmployeeService.GetEmployees()).ToList();
            this.isLoading = false;
        }

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }
    }
}
