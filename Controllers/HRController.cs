using LoginWebAPI.Context;
using LoginWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        private readonly robenContext _context;
        private readonly IConfiguration _configuration;
        public HRController(robenContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        Employee emp = new();
        [HttpPost("AddEmployee")]
        public async Task<ActionResult<Employee>> RegisterEmployee(Employee employee)
        {
            emp.NatId = employee.NatId;
            emp.Surname = employee.Surname;
            emp.Salary = employee.Salary;
            emp.Profession = employee.Profession;
            emp.Phone = employee.Phone;
            emp.FirstName = employee.FirstName;
            emp.Supervisor = employee.Supervisor;
            emp.Role = employee.Role;
            emp.Epin = employee.Epin;
            emp.Estatus = employee.Estatus;
            emp.Country = employee.Country;
            emp.SubCounty = employee.SubCounty;
            emp.County = employee.County;
            emp.Krapin = employee.Krapin;
            emp.MiddleName = employee.MiddleName;
            emp.Village = employee.Village;

            if (_context.Employees == null)
                return Problem("Entity set 'robenContext.Employee'  is null.");
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync(); 
            return CreatedAtAction("GetEmployees", new { id = emp.Id }, emp);
        }

        [HttpGet("ListEmpoyees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_context.Employees == null)
                return NotFound();
            return await _context.Employees.ToListAsync();
        }
        Casual cass = new();
        [HttpPost("RegisterCasuals")]
        public async Task<ActionResult<Casual>> RegisterCasuals(Casual casual)
        {
            cass.Surname = casual.Surname;
            cass.FirstName = casual.FirstName;  
            cass.Wages = casual.Wages;
            cass.Estatus = casual.Estatus;
            cass.Epin = casual.Epin;
            cass.Department = casual.Department;
            cass.MiddleName = casual.MiddleName;
            cass.Phone = casual.Phone;
            cass.Supervisor = casual.Supervisor;
            cass.NatId = casual.NatId;
            cass.OvertimeRates = casual.OvertimeRates;
            if (_context.Casuals == null)
                return Problem("Entity set 'robenContext.Casual'  is null.");
            _context.Casuals.Add(cass);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAllCasuals", new { id = cass.Id }, cass);
        }
        [HttpGet("ListCasuals")]
        public async Task<ActionResult<IEnumerable<Casual>>> GetAllCasuals()
        {
            if(_context.Casuals == null)
                return BadRequest();
            return await _context.Casuals.ToListAsync();
        }
        Fleetassigned magari = new();
        [HttpPost("RegisterFleet")]
        public async Task<ActionResult<Fleetassigned>> RegisterFleet(Fleetassigned fleet)
        {
            //if (_context.Fleetassigneds == null)
            //    return NotFound();
            //var sysLogin = await _context.Fleetassigneds.FindAsync(fleet.Plate);
            //if (sysLogin != null)
            //    if (sysLogin.Plate == fleet.Plate &&
            //        sysLogin.Statuss == fleet.Statuss)
            //        return BadRequest();
            
            magari.Plate = fleet.Plate;
            magari.Projectz = fleet.Projectz;
            magari.Statuss = fleet.Statuss;
            magari.FullName = fleet.FullName;
            magari.Assigneed = fleet.Assigneed;
            magari.Epin = fleet.Epin;
            magari.NatId = fleet.NatId;
            magari.Statuss = fleet.Statuss;

            if (_context.Fleetassigneds==null)
                return Problem("Entity set 'robenContext.Fleetassigned'  is null.");
            _context.Fleetassigneds.Add(magari);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAllFleet", new { id = cass.Id }, cass);
        }
        [HttpGet("ListFleet")]
        public async Task<ActionResult<IEnumerable<Fleetassigned>>> GetAllFleet()
        {
            if (_context.Fleetassigneds == null)
                return NotFound();
            return await _context.Fleetassigneds.ToListAsync();
        }
    }
}
