using BlazorServer.Services.Employee;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Pages.BaseClass.EmployeeBC
{
    public class Details : ComponentBase
    {
        [Inject]
        private IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected Employee Employee { get; set; } = new Employee();
        protected bool isLoading = false;
        
        protected bool isShow { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.isLoading = true;
            this.Employee = await this.EmployeeService.GetEmployee(Int32.Parse(this.Id));
            this.isLoading = false;
        }

        protected void HideFooter()
        {
            if (isShow)
            {
                this.isShow = false;
            }
            else
            {
                this.isShow = true;
            }
        }
    }
}
