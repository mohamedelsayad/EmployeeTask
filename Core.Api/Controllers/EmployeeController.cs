using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Core.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly EmployeeDBContext _context;

        public EmployeeController(EmployeeDBContext context)
        {
            _context = context;
        }


        public IActionResult GetEmployees(DateTime? fromDate, DateTime? toDate)
        {

            List<Employee> lst = _context.Employees.Where(x =>
            (fromDate == null || (x.HiringDate.Date >= fromDate.Value.Date))
            && (toDate == null || x.HiringDate.Date <= toDate.Value.Date)
           ).ToList();

            return Ok(lst);
        }



        [HttpPost]
        public IActionResult SaveEmployee([FromBody]Employee model)
        {
            if (model.EmployeeId == 0)
            { // add new 

                _context.Employees.Add(model);
                _context.SaveChanges();
            }
            else  // update
            {

                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

            }


            return Ok("1");

        }


        [HttpDelete("{id}")]

        public IActionResult DeleteEmployee(int id)
        {

            Employee emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return Ok("1");
        }



        public IActionResult AllEmployees()
        {

            return Ok(_context.Employees.ToList());
        }






    }
}