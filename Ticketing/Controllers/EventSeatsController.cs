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
    public class EventSeatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventSeatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EventSeats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventSeat>>> GetEventSeats()
        {
            return await _context.EventSeats.ToListAsync();
        }

        // GET: api/EventSeats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventSeat>> GetEventSeat(Guid id)
        {
            var eventSeat = await _context.EventSeats.FindAsync(id);

            if (eventSeat == null)
            {
                return NotFound();
            }

            return eventSeat;
        }

        // PUT: api/EventSeats/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventSeat(Guid id, EventSeat eventSeat)
        {
            if (id != eventSeat.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventSeat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventSeatExists(id))
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

        // POST: api/EventSeats
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EventSeat>> PostEventSeat(EventSeat eventSeat)
        {
            _context.EventSeats.Add(eventSeat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventSeat", new { id = eventSeat.Id }, eventSeat);
        }

        // DELETE: api/EventSeats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventSeat>> DeleteEventSeat(Guid id)
        {
            var eventSeat = await _context.EventSeats.FindAsync(id);
            if (eventSeat == null)
            {
                return NotFound();
            }

            _context.EventSeats.Remove(eventSeat);
            await _context.SaveChangesAsync();

            return eventSeat;
        }

        private bool EventSeatExists(Guid id)
        {
            return _context.EventSeats.Any(e => e.Id == id);
        }
    }
}
