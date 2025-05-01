using APIdemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIdemo.Services
{
    public interface IEmployeeService
    {
        Task<ActionResult<Employee>?> GetEmployee(int id);

        Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee();

        Task<ActionResult<Employee>> Add(Employee employee);
        Task<Employee> Update(int id, Employee employeeChanges);
        Task<Employee> Delete(int id);

    }
}
