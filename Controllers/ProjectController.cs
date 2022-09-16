using LoginWebAPI.Context;
using LoginWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net.NetworkInformation;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly robenContext _context;
        private readonly IConfiguration _configuration;
        public ProjectController(robenContext context, IConfiguration configuration)
        {
            _configuration = configuration; 
            _context = context; 
        }
        Contract tender = new();
        [HttpPost("RegisterProjects")]
        public async Task<ActionResult<Contract>> RegisterContracts(Contract contract)
        {
            tender.Road = contract.Road;
            tender.ProjectName = contract.ProjectName;
            tender.StartD = contract.StartD;
            tender.Surveyor = contract.Surveyor;
            tender.Resident = contract.Resident;
            tender.ProjectType = contract.ProjectType;
            tender.Distance = contract.Distance;
            tender.Cost = contract.Cost;
            tender.Engineer = contract.Engineer;
            tender.Client = contract.Client;
            tender.ExpectedD = contract.ExpectedD;
            tender.RevisedD = contract.RevisedD;
            tender.SignedOn = contract.SignedOn;
            
            if(_context.Contracts == null)
                return Problem("Entity set 'robenContext.Contract'  is null.");
            _context.Contracts.Add(tender);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProjects", new { id = tender.Id }, tender);
        }
        [HttpGet("ListProjects")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetProjects()
        {
            if(_context.Contracts==null)
                return BadRequest();
            return await _context.Contracts.ToListAsync();
        }
        Activitiza matendo = new();
        Taska tendo = new();
        [HttpPost("RegisterActivities")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Activitiza>> RegisterActivitiza(Activitiza activitiza)
        {
            matendo.MyActivitiz = activitiza.MyActivitiz;
            matendo.ActStartDate = activitiza.ActStartDate;
            matendo.ActEndDate = activitiza.ActEndDate;
            matendo.ActDependsOn = activitiza.ActDependsOn;
            matendo.ActCompCreteria = activitiza.ActCompCreteria;
            matendo.ActName = activitiza.ActName;
            matendo.ProjectName = activitiza.ProjectName;
            if(_context.Activitizas == null)
                return Problem("Entity set 'robenContext.Activitiza'  is null.");
            _context.Activitizas.Add(matendo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetActvitiza", new { id = matendo.Id }, matendo);
        }
        [HttpGet("ListActivities")]
        public async Task<ActionResult<IEnumerable<Activitiza>>> GetActvitiza()
        {
            if(_context.Activitizas == null)
                return BadRequest();
            return await _context.Activitizas.ToListAsync();
        }
        [HttpPost("RegisterTasks")]
        public async Task<ActionResult<Taska>> RegisterTaskas(Taska taska)
        {
            tendo.TasStartDate = taska.TasStartDate;
            tendo.TasDependsOn = taska.TasDependsOn;
            tendo.TasEndDate = taska.TasEndDate;
            tendo.ActId = taska.ActId;
            tendo.Activitiz = taska.Activitiz;
            tendo.TasCompCreteria = taska.TasCompCreteria;
            
            if(_context.Taskas == null)
                return Problem("Entity set 'robenContext.Taska'  is null.");
            _context.Taskas.Add(tendo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTaskas", new { id = matendo.Id }, matendo);
        }
        [HttpGet("ListTasks")]
        public async Task<ActionResult<IEnumerable<Taska>>> GetTaskas()
        {
            if(_context.Taskas == null)
                return NotFound();
            return await _context.Taskas.ToListAsync();
        }
        Subtaska wera = new();
        [HttpPost("RegisterSubTasks")]
        public async Task<ActionResult<Subtaska>> RegisterSubtaskas(Subtaska subtaska)
        {
            wera.SubTaski = subtaska.SubTaski;
            wera.Trucks = subtaska.Trucks;
            wera.Machines = subtaska.Machines;
            wera.Materials = subtaska.Materials;    
            wera.ActId = subtaska.ActId;
            wera.RdSection = subtaska.RdSection;
            wera.Casuals = subtaska.Casuals;
            wera.Description = subtaska.Description;
            if(_context.Subtaskas == null)
                return Problem("Entity set 'robenContext.Subtaska'  is null.");
            _context.Subtaskas.Add(wera);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSubTaskas", new { id = wera.Id }, wera);
        }
        [HttpGet("ListSubTasks")]
        public async Task<ActionResult<IEnumerable<Subtaska>>> GetSubTaskas()
        {
            if(_context.Subtaskas == null)
                return BadRequest();
            return await _context.Subtaskas.ToListAsync();
        }
    }
}
