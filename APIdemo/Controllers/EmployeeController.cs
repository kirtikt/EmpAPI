using APIdemo.Models;
using APIdemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private  IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>?>> GetEmployees()
        {
            if (await _employeeService.GetAllEmployee() == null)
            {
                return NotFound();
            }

            return await _employeeService.GetAllEmployee();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById_ActionResultOfT(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            return employee == null ? NotFound() : employee;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            try
            {
                await _employeeService.Update(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_employeeService.GetEmployee(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employeeService.Add(employee);
            return CreatedAtAction("GetById_ActionResultOfT", new { id = employee.Id }, employee);
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.Delete(id);
            return NoContent();
        }
    }
}












//[HttpGet]
//        public IEnumerable<Employee> Get()
//        {
//            return _employeeService.GetAllEmployee();
            
//        }

//        // GET api/<EmployeeController>/5
//        [HttpGet("{id}")]
//        public Employee Get(int id)
//        {
//            return _employeeService.GetEmployee(id);
//        }

//        // POST api/<EmployeeController>
//        [HttpPost]
//        public void Post([FromBody] Employee emp)
//        {
//            _employeeService.Add(emp);
//        }

//        // PUT api/<EmployeeController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] Employee emp)
//        {
//            var model = _employeeService.GetEmployee(id);
//            model.Name = emp.Name;
//            model.Email = emp.Email;
//            model.DepartmentId = emp.DepartmentId;
//            _employeeService.Update(model);

//        }

//        // DELETE api/<EmployeeController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            var model = _employeeService.GetEmployee(id);
//            if(model != null)
//            {
//                _employeeService.Delete(id);
//            }


//        }
   
