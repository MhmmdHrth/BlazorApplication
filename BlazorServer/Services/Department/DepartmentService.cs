using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.Services.Employee
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var response = await httpClient.GetFromJsonAsync<EmployeeManagement.Models.Department>($"/api/department/{id}");
            return response;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var response = await httpClient.GetFromJsonAsync<EmployeeManagement.Models.Department[]>($"/api/department/GetDepartments");
            return response;
        }
    }
}
