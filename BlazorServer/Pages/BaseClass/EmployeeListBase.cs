using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Pages.BaseClass
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override Task OnInitializedAsync()
        {
            this.LoadEmployees();
            return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            Employee e1 = new Employee
            {
                Id = 1,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DOB = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                Department = new Department
                {
                    Id = 1,
                    Name = "JKE"
                },
                PhotoPath = "images/rambut.jpg"
            };

            Employee e2 = new Employee
            {
                Id = 2,
                FirstName = "Harith",
                LastName = "Lai",
                Email = "harith@gmail.com",
                DOB = new DateTime(1999, 9, 23),
                Gender = Gender.Male,
                Department = new Department
                {
                    Id = 2,
                    Name = "JKA"
                },
                PhotoPath = "images/gambar latest.JPG"
            };

            Employees = new List<Employee> { e1, e2 };
        }
    }
}
