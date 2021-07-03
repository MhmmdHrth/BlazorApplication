using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DOB = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 1,
                PhotoPath = "images/rambut.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                FirstName = "Harith",
                LastName = "Lai",
                Email = "harith@gmail.com",
                DOB = new DateTime(1999, 9, 23),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/gambar latest.JPG"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                Name = "JKE"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 2,
                Name = "JKA"
            });
        }
    }
}
