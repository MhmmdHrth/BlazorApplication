using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<EmployeeManagement.Models.Employee> GetEmployee(int id)
        {
            var response = await httpClient.GetFromJsonAsync<EmployeeManagement.Models.Employee>($"/api/employee/{id}");
            return response;
        }

        public async Task<IEnumerable<EmployeeManagement.Models.Employee>> GetEmployees()
        {
            var response = await httpClient.GetFromJsonAsync<EmployeeManagement.Models.Employee[]>("/api/employee/GetEmployees");
            return response;
        }
    }
}
