using LoginWebAPI.Context;
using LoginWebAPI.Data;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly robenContext _context;
        private readonly IConfiguration _configuration;
        public AssetsController(robenContext context,IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context; 
        }
        Machinery tinga = new();
        [HttpPost("RegisterMachinery")]
        public async Task<ActionResult<Machinery>> RegisterMachinery(Machinery machinery)
        {
            tinga.ChasisNo = machinery.ChasisNo;
            tinga.EngineNo = machinery.EngineNo;
            tinga.RegNo = machinery.RegNo;
            tinga.Cost = machinery.Cost;
            tinga.Logbook = machinery.Logbook;
            tinga.Mcondition = machinery.Mcondition;
            tinga.UsedStatus = machinery.UsedStatus;
            tinga.VehiclType = machinery.Mcondition;
            tinga.Yearz = machinery.Yearz;
            if(_context.Machineries == null)
                return Problem("Entity set 'robenContext.Machinery'  is null.");
            _context.Machineries.Add(tinga);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMachinery", new { id = tinga.Id }, tinga);
        }
        [HttpGet("ListMachinery")]
        public async Task<ActionResult<IEnumerable<Machinery>>> GetMachinery()
        {
            if (_context.Machineries == null)
            {
                return NotFound();
            }
            return await _context.Machineries.ToListAsync();
        }
        Vehicle gari = new();
        [HttpPost("RegisterVehicles")]
        public async Task<ActionResult<Vehicle>> RegistarVehicle(Vehicle vehicle)
        {
            gari.ChasisNo = vehicle.ChasisNo;
            gari.EngineNo = vehicle.EngineNo;
            gari.Plate = vehicle.Plate;
            gari.UsedStatus = vehicle.UsedStatus;
            gari.Cost = vehicle.Cost;
            gari.Logbook = vehicle.Logbook;
            gari.Vcondition = vehicle.Vcondition;
            gari.VehiclType = vehicle.VehiclType;
            gari.Yearz = vehicle.Yearz;
            if(vehicle.VehiclType == null)
                return Problem("Entity set 'robenContext.VehiclType'  is null.");
            _context.Vehicles.Add(gari);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVehicle", new { id = tinga.Id }, tinga);
        }

        [HttpGet("ListVehicles")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            if(_context.Vehicles == null)
            {
                return NotFound();
            }
            return await _context.Vehicles.ToListAsync();
        }
    }
}
