using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn6KPI.Models;

namespace DoAn6KPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Targetlists1Controller : ControllerBase
    {
        private readonly DoAnTNKPIContext _context;

        public Targetlists1Controller(DoAnTNKPIContext context)
        {
            _context = context;
        }

        // GET: api/Targetlists1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Targetlist>>> GetTargetlists()
        {
            return await _context.Targetlists.ToListAsync();
        }

        // GET: api/Targetlists1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Targetlist>> GetTargetlist(int id)
        {
            var targetlist = await _context.Targetlists.FindAsync(id);

            if (targetlist == null)
            {
                return NotFound();
            }

            return targetlist;
        }

        // PUT: api/Targetlists1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTargetlist(int id, Targetlist targetlist)
        {
            if (id != targetlist.Idtarget)
            {
                return BadRequest();
            }

            _context.Entry(targetlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TargetlistExists(id))
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

        // POST: api/Targetlists1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Targetlist>> PostTargetlist(Targetlist targetlist)
        {
            _context.Targetlists.Add(targetlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTargetlist", new { id = targetlist.Idtarget }, targetlist);
        }

        // DELETE: api/Targetlists1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Targetlist>> DeleteTargetlist(int id)
        {
            var targetlist = await _context.Targetlists.FindAsync(id);
            if (targetlist == null)
            {
                return NotFound();
            }

            _context.Targetlists.Remove(targetlist);
            await _context.SaveChangesAsync();

            return targetlist;
        }

        private bool TargetlistExists(int id)
        {
            return _context.Targetlists.Any(e => e.Idtarget == id);
        }
    }
}
