using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstWebAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebAPIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id=101,Name="Ramu",Age=21},
            new Employee(){Id=102,Name="Somu",Age=30},
            new Employee(){Id=103,Name="Gomu",Age=25}
        };
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }
        [HttpPost]
        public void Post(Employee employee)
        {
            employees.Add(employee);
        }
        [HttpGet]
        [Route("GetEmployee/{id}")]
        public Employee ABC(int id)
        {
            var emp = employees.Find(e => e.Id == id);
            return emp;
           
        }
        [HttpPut]
        [Route("Update/{id}")]
        public Employee Put(int id,Employee employee)
        {
            var emp = employees.FindIndex(e => e.Id == id);
            employees[emp] = employee;
            return employees[emp];

        }
    }
}
