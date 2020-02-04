﻿using System;
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
    public class TicketPurchasesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketPurchasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TicketPurchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketPurchase>>> GetTicketPurchases()
        {
            return await _context.TicketPurchases.ToListAsync();
        }

        // GET: api/TicketPurchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketPurchase>> GetTicketPurchase(Guid id)
        {
            var ticketPurchase = await _context.TicketPurchases.FindAsync(id);

            if (ticketPurchase == null)
            {
                return NotFound();
            }

            return ticketPurchase;
        }

        // PUT: api/TicketPurchases/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketPurchase(Guid id, TicketPurchase ticketPurchase)
        {
            if (id != ticketPurchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticketPurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketPurchaseExists(id))
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

        // POST: api/TicketPurchases
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TicketPurchase>> PostTicketPurchase(TicketPurchase ticketPurchase)
        {
            _context.TicketPurchases.Add(ticketPurchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketPurchase", new { id = ticketPurchase.Id }, ticketPurchase);
        }

        // DELETE: api/TicketPurchases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketPurchase>> DeleteTicketPurchase(Guid id)
        {
            var ticketPurchase = await _context.TicketPurchases.FindAsync(id);
            if (ticketPurchase == null)
            {
                return NotFound();
            }

            _context.TicketPurchases.Remove(ticketPurchase);
            await _context.SaveChangesAsync();

            return ticketPurchase;
        }

        private bool TicketPurchaseExists(Guid id)
        {
            return _context.TicketPurchases.Any(e => e.Id == id);
        }
    }
}
