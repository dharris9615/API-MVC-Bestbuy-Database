using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mock_BestBuy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _repo.GetEmployees();
            return Ok(JsonConvert.SerializeObject(employees));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _repo.GetEmployee(id);
            return Ok(JsonConvert.SerializeObject(employee));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post(Employee employee)
        {
            var lastEmployeeId = _repo.GetEmployees().LastOrDefault().EmployeeID; 
            employee.EmployeeID = ++lastEmployeeId;
            _repo.InsertEmployee(employee);
        }


        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, Employee employee)
        {
            //var employeeToUpdate = _repo.GetEmployee(id);
            employee.EmployeeID = id;
            _repo.UpdateEmployee(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeeToDelete = _repo.GetEmployee(id);
            _repo.DeleteEmployee(employeeToDelete);
        }
    }
}
