using LoginWebAPI.Context;
using LoginWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        robenContext _context;
        public ReportsController(robenContext context)
        {
            _context = context;
        }
        Reports ripoti = new();
        [HttpPost("RegisterReport")]
        public async Task<ActionResult<Reports>> RegisterReports(Reports reports)
        {
            ripoti.Cod = reports.Cod;
            ripoti.Fname = reports.Fname;
            ripoti.Repor = reports.Repor;
            if(_context.Reports == null)
                return Problem("Entity set 'robenContext.Reports'  is null.");
            _context.Reports.Add(ripoti);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMyReports", new { id = ripoti.ReportsId }, ripoti);
        }
        [HttpGet("Reports")]
        public async Task<ActionResult<IEnumerable<Reports>>> GetMyReports()
        {
            if(_context.Reports == null)
                return NotFound();
            return await _context.Reports.ToListAsync();
        }
    }
}
