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
    public class RowsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: api/Rows
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Row>>> GetRows()
        {
            return await _context.Rows.ToListAsync();
        }

        /// <summary>
        /// GET: api/Rows/5
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Row>> GetRow(Guid id)
        {
            var row = await _context.Rows.FindAsync(id);

            if (row == null)
            {
                return NotFound();
            }

            return row;
        }

        /// <summary>
        /// PUT: api/Rows/5
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https:///aka.ms/RazorPagesCRUD.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRow(Guid id, Row row)
        {
            if (id != row.Id)
            {
                return BadRequest();
            }

            _context.Entry(row).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RowExists(id))
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

        /// <summary>
        /// POST: api/Rows
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https:///aka.ms/RazorPagesCRUD.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Row>> PostRow(Row row)
        {
            _context.Rows.Add(row);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRow", new { id = row.Id }, row);
        }

        /// <summary>
        /// DELETE: api/Rows/5
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Row>> DeleteRow(Guid id)
        {
            var row = await _context.Rows.FindAsync(id);
            if (row == null)
            {
                return NotFound();
            }

            _context.Rows.Remove(row);
            await _context.SaveChangesAsync();

            return row;
        }

        private bool RowExists(Guid id)
        {
            return _context.Rows.Any(e => e.Id == id);
        }
    }
}
