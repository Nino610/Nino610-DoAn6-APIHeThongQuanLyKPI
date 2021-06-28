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
    public class ProgresslistsController : ControllerBase
    {
        private readonly DoAnTNKPIContext _context;

        public ProgresslistsController(DoAnTNKPIContext context)
        {
            _context = context;
        }

        // GET: api/Progresslists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Progresslist>>> GetProgresslists()
        {
            return await _context.Progresslists.ToListAsync();
        }

        // GET: api/Progresslists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Progresslist>> GetProgresslist(int id)
        {
            var progresslist = await _context.Progresslists.FindAsync(id);

            if (progresslist == null)
            {
                return NotFound();
            }

            return progresslist;
        }

        // PUT: api/Progresslists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Route("sua/{id}")]
        public async Task<IActionResult> PutProgresslist(int id, Progresslist progresslist)
        {
            if (id != progresslist.Idprogress)
            {
                return BadRequest();
            }

            _context.Entry(progresslist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgresslistExists(id))
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

        // POST: api/Progresslists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("them")]
        public async Task<ActionResult<Progresslist>> PostProgresslist(Progresslist progresslist)
        {
            _context.Progresslists.Add(progresslist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgresslist", new { id = progresslist.Idprogress }, progresslist);
        }

        // DELETE: api/Progresslists/5
        [HttpDelete("{id}")]
        [Route("xoa/{id}")]
        public async Task<ActionResult<Progresslist>> DeleteProgresslist(int id)
        {
            var progresslist = await _context.Progresslists.FindAsync(id);
            if (progresslist == null)
            {
                return NotFound();
            }

            _context.Progresslists.Remove(progresslist);
            await _context.SaveChangesAsync();

            return progresslist;
        }

        private bool ProgresslistExists(int id)
        {
            return _context.Progresslists.Any(e => e.Idprogress == id);
        }
    }
}
