using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using Woekers.DB;
using Woekers.Models;

namespace Woekers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly DbConnection _dbconnection;
        public EmployeeController(DbConnection dbConnection)
        {
            _dbconnection = dbConnection;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employee = await _dbconnection.EmployeesLD.ToListAsync();
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {

            await _dbconnection.EmployeesLD.AddAsync(employeeRequest);
            await _dbconnection.SaveChangesAsync();
            return Ok(employeeRequest);
        }
        [HttpGet]
        [Route("{IdNumber}")]

        public async Task<IActionResult> GetEmployee(int IdNumber)
        {
            Console.WriteLine(IdNumber);
            var employee = await _dbconnection.EmployeesLD.FirstOrDefaultAsync(x => x.IdNumber == IdNumber);

            Console.WriteLine(IdNumber);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        
        public async Task<IActionResult> UpdateEmployee([FromBody]  Employee updateEmployeeRequest)
        {
            var employee=await  _dbconnection.EmployeesLD.FirstOrDefaultAsync(x => x.IdNumber == updateEmployeeRequest.IdNumber);
            Console.WriteLine(employee);
            if(employee== null)
            {
                return NotFound();
            }
            employee.FirstName = updateEmployeeRequest.FirstName;
            employee.LastName = updateEmployeeRequest.LastName;
            employee.Email= updateEmployeeRequest.Email;
            employee.PhoneNo= updateEmployeeRequest.PhoneNo;
            employee.BasicSalary = updateEmployeeRequest.BasicSalary;
            employee.Type= updateEmployeeRequest.Type;


            await _dbconnection.SaveChangesAsync();
            return Ok(employee);

        }

        [HttpDelete]
        [Route("{IdNumber}")]
        public async Task<IActionResult> DeleteEmployee(int IdNumber)
        {
            Console.WriteLine(IdNumber);
            var employee = await _dbconnection.EmployeesLD.FirstOrDefaultAsync(x => x.IdNumber == IdNumber);

            Console.WriteLine(IdNumber);
            if (employee == null)
            {
                return NotFound();
            }
             _dbconnection.EmployeesLD.Remove(employee);
            await _dbconnection.SaveChangesAsync();
            return Ok("Done");
        }

    }
}
