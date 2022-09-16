using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginWebAPI.Data;
using LoginWebAPI.Context;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeighbridgeController : ControllerBase
    {
        private readonly robenContext _context;
        private readonly IConfiguration _configuration;
        public WeighbridgeController(robenContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpGet("ListSalesPreview")]
        public async Task<ActionResult<IEnumerable<SalesPreview>>> GetSalesPreview()
        {
            if (_context.SalesPreviews == null)
                return NotFound();
            return await _context.SalesPreviews.ToListAsync();
        }
        Weighbridgesale mauzo { get; set; } = new();
        [HttpPost("RegisterWBSales")]
        public async Task<ActionResult<Weighbridgesale>> RegisterWBSales(Weighbridgesale wbsaletb)
        {
            mauzo.Plate = wbsaletb.Plate;
            mauzo.DateTime = wbsaletb.DateTime;
            mauzo.Ticket = wbsaletb.Ticket;
            mauzo.Driva = wbsaletb.Driva;
            mauzo.Material = wbsaletb.Material;
            mauzo.TareWeight = wbsaletb.TareWeight;
            mauzo.Balance = wbsaletb.Balance;
            mauzo.GrossWeight = wbsaletb.GrossWeight;
            mauzo.InBank = wbsaletb.InBank;
            mauzo.TonageRate = wbsaletb.TonageRate;
            mauzo.Phone = wbsaletb.Phone;
            mauzo.TotalAmount = wbsaletb.TotalAmount;
            mauzo.Tonage = wbsaletb.Tonage;
            if(_context.Weighbridgesales == null)
                return Problem("Entity set 'robenContext.Weighbridgesale'  is null.");
            _context.Weighbridgesales.Add(mauzo);
            await _context.SaveChangesAsync();  
            return CreatedAtAction("GetWBsales", new { id = mauzo.Id }, mauzo);
        }
        [HttpGet("ListWeighbridgeSale")]
        public async Task<ActionResult<IEnumerable<Weighbridgesale>>> GetWBsales()
        {
            if (_context.Weighbridgesales == null)
                return NotFound();
            return await _context.Weighbridgesales.ToListAsync();
        }
        Secondweight tare { get; set; } = new();
        [HttpPost("RegisterTareWeight")]
        public async Task<ActionResult<Secondweight>> RegisterTareWeight(Secondweight secondweight)
        {
            tare.Sweight = secondweight.Sweight;
            tare.Ticket = secondweight.Ticket;
            tare.FirstWeightCode = secondweight.FirstWeightCode;
            if(_context.Secondweights == null)
                return Problem("Entity set 'robenContext.Secondweight'  is null.");
            _context.Secondweights.Add(tare);
            await _context.SaveChangesAsync();  
            return CreatedAtAction("GetTareWeight", new { id = tare.Id }, tare);
        }
        [HttpGet("ListTareWeight")]
        public async Task<ActionResult<IEnumerable<Secondweight>>> GetTareWeight()
        {
            if(_context.Secondweights == null)
                return NotFound();
            return await _context.Secondweights.ToListAsync();
        }
        Firstweight gross { get; set; } = new();
        [HttpPost("RegisterGrossWeight")]
        public async Task<ActionResult<Firstweight>> RegisterGrossWeight(Firstweight firstweight)
        {
            gross.Material = firstweight.Material;
            gross.Weight = firstweight.Weight;
            gross.Ticket = firstweight.Ticket;
            gross.Driver = firstweight.Driver;
            gross.Amount = firstweight.Amount;
            gross.DateTime = firstweight.DateTime;
            gross.Phone = firstweight.Phone;
            gross.Plate = firstweight.Plate;
            gross.Time = firstweight.Time;
            if(_context.Firstweights == null)
                return Problem("Entity set 'robenContext.Firstweight'  is null.");
            _context.Firstweights.Add(gross);
            await _context.SaveChangesAsync();  
            return CreatedAtAction("GetGrossWeight", new { id = gross.Id }, gross);
        }
        
        [HttpGet("ListGrossWeight")]
        public async Task<ActionResult<IEnumerable<Firstweight>>> GetGrossWeight()
        {
            if(_context.Firstweights == null)
                return NotFound();
            return await _context.Firstweights.ToListAsync();
        }
        Commodity muthanga { get; set; } = new();
        [HttpPost("RegisterNewMaterial")]
        public async Task<ActionResult<Commodity>> RegisterCommodity(Commodity commodity)
        {
            muthanga.Materials = commodity.Materials;
            muthanga.Matserial = commodity.Matserial;
            muthanga.MaterialCost = commodity.MaterialCost;
            if(_context.Commodities == null)
                return Problem("Entity set 'robenContext.Commodity'  is null.");
            _context.Commodities.Add(muthanga);
            await _context.SaveChangesAsync();  
            return CreatedAtAction("GetMaterials", new { id = muthanga.Id }, muthanga);
        }
        [HttpGet("ListWBMaterials")]
        public async Task<ActionResult<IEnumerable<Commodity>>> GetMaterials()
        {
            if(_context.Commodities == null)
                return BadRequest();
            return await _context.Commodities.ToListAsync();
        }
        Driver kadere = new();
        [HttpPost("RegisterNewDriver")]
        public async Task<ActionResult<Driver>> RegisterDriver(Driver driver)
        {
            kadere.DriverId = driver.Id;
            kadere.DriverPhone = driver.DriverPhone;
            kadere.Driva = driver.Driva;
            kadere.Plate = driver.Plate;
            if(_context.Drivers == null)
                return Problem("Entity set 'robenContext.Driver'  is null.");
            _context.Drivers.Add(kadere);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMyDrivers", new { id = kadere.Id }, kadere);
        }
        [HttpGet("ListDrivers")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetMyDrivers()
        {
            if (_context.Drivers == null)
                return BadRequest();
            return await _context.Drivers.ToListAsync();
        }
    }
}
