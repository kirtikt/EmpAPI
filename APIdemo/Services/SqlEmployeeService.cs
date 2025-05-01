using APIdemo.Models;
using APIdemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIdemo.Services
{
    public class SqlEmployeeService : IEmployeeService
    {
        private readonly Appdbcontext context;
        public SqlEmployeeService(Appdbcontext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<Employee>> Add(Employee employee)
        {
            context.Employee.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }


        public async Task<Employee> Delete(int id)
        {
            Employee? employee = context.Employee.Find(id);
            if (employee != null)
            {
                context.Employee.Remove(employee);
                await context.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<ActionResult<IEnumerable<Employee>?>> GetAllEmployee()
        {
            if (context.Employee == null)
            {
                return null;
            }
            return await context.Employee.Include(a => a.Department).ToListAsync();

        }


        public async Task<ActionResult<Employee>?> GetEmployee(int Id)
        {
            if(context.Employee == null)
            {
                return null;

            }
            var emp = await context.Employee.FindAsync(Id);

            if(emp == null)
            {
                return null;
            }
            return emp;
            
        }

        public async Task<Employee?> Update(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return null;
            }

            context.Entry(employee).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;

        }
        private bool EmployeeExists(int id)
        {
            return (context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

       
    }

