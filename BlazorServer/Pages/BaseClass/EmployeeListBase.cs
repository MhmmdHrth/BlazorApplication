﻿using EmployeeManagement.Models;
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
        protected IEnumerable<Employee> Employees { get; set; }
        protected bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            //var task = new { this.LoadEmployees(), this.test() };
            var task = Task.Factory.StartNew(() => this.LoadEmployees())
                                   .ContinueWith(x => this.test());

            await Task.WhenAll(task);
        }

        private void LoadEmployees()
        {
            this.isLoading = true;
            Thread.Sleep(3000);
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
            this.isLoading = false;
        }

        private void test()
        {

        }
    }
}
