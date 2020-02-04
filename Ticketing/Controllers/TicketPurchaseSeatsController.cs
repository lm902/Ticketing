using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketing.Model;

namespace Ticketing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPurchaseSeatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketPurchaseSeatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TicketPurchaseSeats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketPurchaseSeat>>> GetTicketPurchaseSeats()
        {
            return await _context.TicketPurchaseSeats.ToListAsync();
        }

        // GET: api/TicketPurchaseSeats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketPurchaseSeat>> GetTicketPurchaseSeat(Guid id)
        {
            var ticketPurchaseSeat = await _context.TicketPurchaseSeats.FindAsync(id);

            if (ticketPurchaseSeat == null)
            {
                return NotFound();
            }

            return ticketPurchaseSeat;
        }

        // PUT: api/TicketPurchaseSeats/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketPurchaseSeat(Guid id, TicketPurchaseSeat ticketPurchaseSeat)
        {
            if (id != ticketPurchaseSeat.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketPurchaseSeat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketPurchaseSeatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TicketPurchaseSeats
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TicketPurchaseSeat>> PostTicketPurchaseSeat(TicketPurchaseSeat ticketPurchaseSeat)
        {
            _context.TicketPurchaseSeats.Add(ticketPurchaseSeat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketPurchaseSeat", new { id = ticketPurchaseSeat.Id }, ticketPurchaseSeat);
        }

        // DELETE: api/TicketPurchaseSeats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketPurchaseSeat>> DeleteTicketPurchaseSeat(Guid id)
        {
            var ticketPurchaseSeat = await _context.TicketPurchaseSeats.FindAsync(id);
            if (ticketPurchaseSeat == null)
            {
                return NotFound();
            }

            _context.TicketPurchaseSeats.Remove(ticketPurchaseSeat);
            await _context.SaveChangesAsync();

            return ticketPurchaseSeat;
        }

        private bool TicketPurchaseSeatExists(Guid id)
        {
            return _context.TicketPurchaseSeats.Any(e => e.Id == id);
        }
    }
}
