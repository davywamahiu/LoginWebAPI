using LoginWebAPI.Context;
using LoginWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly robenContext _context;
        private readonly IConfiguration _configuration;
        public AccountsController(robenContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> GetCustomer(int id, Weibrideaccount wbacc)
        {
            if (id != wbacc.Id)
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
        Wbcustomerdeposit deposit = new();
        [HttpPost("RegisterWBbalances")]
        public async Task<ActionResult<Wbcustomerdeposit>> RegisterWBAccChanges(Wbcustomerdeposit Deposit)
        {
            deposit.Plate = Deposit.Plate;
            deposit.Driva = Deposit.Driva;
            deposit.Material = Deposit.Material;
            deposit.Tonage = Deposit.Tonage;
            deposit.Balance = Deposit.Balance;
            deposit.AccountNo = Deposit.AccountNo;
            deposit.Deposit = Deposit.Deposit;
            deposit.PaidOn = Deposit.PaidOn;
            deposit.MpesaUid = Deposit.MpesaUid;
            deposit.Phone = Deposit.Phone;
            deposit.SpentAmount = Deposit.SpentAmount;
            if (_context.Wbcustomerdeposits == null)
                return Problem("Entity set 'robenContext.Wbcustomerdeposit'  is null.");
            _context.Wbcustomerdeposits.Add(deposit);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetWeibrideAccDeposit", new { id = deposit.Id }, deposit);
        }
        [HttpGet("ListWBccountsBalance")]
        public async Task<ActionResult<IEnumerable<Wbcustomerdeposit>>> GetWeibrideAccDeposit()
        {
            if (_context.Wbcustomerdeposits == null)
                return BadRequest();
            return await _context.Wbcustomerdeposits.ToListAsync();
        }
        Weibrideaccount wbAccoount = new();
        [HttpPost("RegisterWBPayments")]
        public async Task<ActionResult<Weibrideaccount>> RegisterWBAcc(Weibrideaccount wbacc)
        {
            wbAccoount.AccountNo = wbacc.AccountNo;
            wbAccoount.Balance = wbacc.Balance;
            wbAccoount.Plate = wbacc.Plate;
            wbAccoount.SpentAmount = wbacc.SpentAmount;
            if(_context.Weibrideaccounts == null)
                return Problem("Entity set 'robenContext.Weibrideaccount'  is null.");
            _context.Weibrideaccounts.Add(wbAccoount);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetWeibrideAcc", new { id = wbAccoount.Id }, wbAccoount);
        }
        [HttpGet("ListWeighbridgeAccounts")]
        public async Task<ActionResult<IEnumerable<Weibrideaccount>>> GetWeibrideAcc()
        {
            if(_context.Weibrideaccounts == null)
                return BadRequest();
            return await _context.Weibrideaccounts.ToListAsync();
        }
    }
}
