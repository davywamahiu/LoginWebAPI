using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginWebAPI.Context;
using LoginWebAPI.Data;
using LoginWebAPI.Models;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysLoginsController : ControllerBase
    {
        private readonly robenContext _context;
        private readonly IConfiguration _configuration;
        public SysLoginsController(robenContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        SysLogin user = new();
        // GET: api/SysLogins
        [HttpGet("AllUsers")]
        //[Route ("AllUsers"), Authorize(Roles = "Admin,PowerUser")]
        public async Task<ActionResult<IEnumerable<SysLogin>>> GetSysLogins()
        {
          if (_context.SysLogins == null)
          {
              return NotFound();
          }
            return await _context.SysLogins.ToListAsync();
        }
        //Handle Fuel API
        [HttpGet("AllFuel")]
        //[Authorize("Attendant")]
        public async Task<ActionResult<IEnumerable<Fuelsupply>>> GetFuelSupplly()
        {
            if (_context.Fuelsupplies == null)
            {
                return NotFound();
            }
            return await _context.Fuelsupplies.ToListAsync();
        }
        Fuelsupply fuel = new();
        [HttpPost("AddFuel")]
        //[Authorize ("Attendant")]
        public async Task<ActionResult<IEnumerable<Fuelsupply>>> RegisterFuel(Fuelsupply fuelsupply)
        {
            fuel.NumberPlate = fuelsupply.NumberPlate;
            fuel.SupplyDate = fuelsupply.SupplyDate;
            fuel.Supplier = fuelsupply.Supplier;
            fuel.SupplierPhone = fuelsupply.SupplierPhone;
            fuel.SuppliedLitters = fuelsupply.SuppliedLitters;
            fuel.Driva = fuelsupply.Driva;
            fuel.VehicleId = fuelsupply.VehicleId;
            fuel.SupplyTime = fuelsupply.SupplyTime;
            fuel.FuelType = fuelsupply.FuelType;
            if (_context.Fuelsupplies == null)
            {
                return Problem("Entity set 'robenContext.SysLogins'  is null.");
            }
            _context.Fuelsupplies.Add(fuel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuelSupplly", new { VehicleId =  fuel.VehicleId}, fuel);
        }
        [HttpGet("ListSuppliers")]
        public async Task<ActionResult<IEnumerable<Mysupplier>>> GetSuppliers()
        {
            if (_context.Mysuppliers == null)
            {
                return NotFound();
            }
            return await _context.Mysuppliers.ToListAsync();
        }
        [HttpGet("ListDrivers")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            return await _context.Drivers.ToListAsync();
        }
        [HttpGet("ListFuels")]
        public async Task<ActionResult<IEnumerable<Fuel>>> GetFuels()
        {
            if (_context.Fuels == null)
            {
                return NotFound();
            }
            return await _context.Fuels.ToListAsync();
        }
        [HttpGet("ListVehicles")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }
            return await _context.Vehicles.ToListAsync();
        }
        [HttpGet("ListEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            return await _context.Employees.ToListAsync();
        }
        [HttpGet("Refueled")]
        //[Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<Refuel>>> GetRefueled()
        {
            if (_context.Refuels == null)
            {
                return NotFound();
            }
            return await _context.Refuels.ToListAsync();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, SysLogin wbacc)
        {
            if (id != wbacc.UserId)
                return BadRequest();
            _context.Entry(wbacc).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }
        Refuel fuels  = new();
        [HttpPost("Refuel")]
        //[Authorize("Attendant")]
        public async Task<ActionResult<IEnumerable<Refuel>>> RefuelVehicle(Refuel fuelsupply)
        {
            fuels.RefuelDate = fuelsupply.RefuelDate;
            fuels.NumberPlate = fuelsupply.NumberPlate;
            fuels.PrevMilage = fuelsupply.PrevMilage;
            fuels.Driver = fuelsupply.Driver;
            fuels.FuelType = fuelsupply.FuelType;
            fuels.Refuelier = fuelsupply.Refuelier; 
            fuels.RefuelTime = fuelsupply.RefuelTime;
            fuels.Milage = fuelsupply.Milage;
            fuels.VehicleId = fuelsupply.VehicleId;
            fuels.RefueliedLitters = fuelsupply.RefueliedLitters;
            
            if (_context.Refuels == null)
            {
                return Problem("Entity set 'robenContext.SysLogins'  is null.");
            }
            _context.Refuels.Add(fuels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRefueled", new { VehicleId =  fuels.VehicleId}, fuels);
        }
        [HttpGet("ListFuelSuppliers")]
        public async Task<ActionResult<IEnumerable<Mysupplier>>> ListFuelSuppliers()
        {
            if (_context.Mysuppliers == null)
            {
                return NotFound();
            }
            return await _context.Mysuppliers.ToListAsync();
        }
        Mysupplier supplier = new();
        [HttpPost("AddFuelSupplier")]
        public async Task<ActionResult<Mysupplier>> RegisterSupplier(Mysupplier mysupplier)
        {
            supplier.Driver = mysupplier.Driver;
            supplier.Plate = mysupplier.Plate;
            supplier.SupplierPhone = mysupplier.SupplierPhone;
            supplier.Supplier = mysupplier.Supplier;
            if (_context.Mysuppliers == null)
            {
                return Problem("Entity set 'robenContext.Mysupplier'  is null.");
            }
            _context.Mysuppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return CreatedAtAction("ListFuelSuppliers", new { id = supplier.Id }, supplier);

        }
        //End FuelSupply Handler
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            
            if (_context.SysLogins == null)
                return BadRequest("Data not found.");
            var sysLogin = await _context.SysLogins.FindAsync(request.Username);

            if (sysLogin == null)
                return BadRequest("User1 not found.");

            if (!VerifyPasswordHash(request.Password, sysLogin.PasswordHash, sysLogin.PasswordSalt))
                return BadRequest("Passwords did not match.");
            string token = CreateToken(sysLogin);
            var result = new
            {
                token,
                sysLogin
            };
            //return sysLogin.Username;

            //var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken);

            return Ok(result);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }



        [HttpPost("RegisterUser")]
        //[Authorize("PowerUser")]
        public async Task<ActionResult<SysLogin>> Register(LoginUser request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = request.Username1;
            user.IsAdmin = request.IsAdmin;
            user.CreatedAt = request.CreatedAt;
            user.LastLogin = request.LastLogin;
            user.Phone = request.Phone;
            user.Role = request.Role;
            user.Name = request.Name;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            if (_context.SysLogins == null)
            {
                return Problem("Entity set 'robenContext.SysLogins'  is null.");
            }
            _context.SysLogins.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSysLogins", new { id = user.UserId }, user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private string CreateToken(SysLogin user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:ServerSecret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        // POST: api/SysLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        private bool SysLoginExists(long id)
        {
            return (_context.SysLogins?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
