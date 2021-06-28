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
    public class GroupkpisController : ControllerBase
    {
        private readonly DoAnTNKPIContext _context;

        public GroupkpisController(DoAnTNKPIContext context)
        {
            _context = context;
        }

        // GET: api/Groupkpis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groupkpi>>> GetGroupkpis()
        {
            return await _context.Groupkpis.ToListAsync();
        }

        // GET: api/Groupkpis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groupkpi>> GetGroupkpi(int id)
        {
            var groupkpi = await _context.Groupkpis.FindAsync(id);

            if (groupkpi == null)
            {
                return NotFound();
            }

            return groupkpi;
        }

        // PUT: api/Groupkpis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Route("sua/{id}")]
        public async Task<IActionResult> PutGroupkpi(int id, Groupkpi groupkpi)
        {
            if (id != groupkpi.Idgroupkpi)
            {
                return BadRequest();
            }

            _context.Entry(groupkpi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupkpiExists(id))
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

        // POST: api/Groupkpis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("them")]
        public async Task<ActionResult<Groupkpi>> PostGroupkpi(Groupkpi groupkpi)
        {
            _context.Groupkpis.Add(groupkpi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GroupkpiExists(groupkpi.Idgroupkpi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGroupkpi", new { id = groupkpi.Idgroupkpi }, groupkpi);
        }

        // DELETE: api/Groupkpis/5
        [HttpDelete("{id}")]
        [Route("xoa/{id}")]
        public async Task<ActionResult<Groupkpi>> DeleteGroupkpi(int id)
        {
            var groupkpi = await _context.Groupkpis.FindAsync(id);
            if (groupkpi == null)
            {
                return NotFound();
            }

            _context.Groupkpis.Remove(groupkpi);
            await _context.SaveChangesAsync();

            return groupkpi;
        }

        private bool GroupkpiExists(int id)
        {
            return _context.Groupkpis.Any(e => e.Idgroupkpi == id);
        }
    }
}
