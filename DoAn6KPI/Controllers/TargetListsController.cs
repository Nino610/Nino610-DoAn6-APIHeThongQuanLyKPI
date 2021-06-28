using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn6KPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAn6KPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TargetListsController : ControllerBase
	{
		private readonly DoAnTNKPIContext _context;
		public TargetListsController(DoAnTNKPIContext context)
		{
			_context = context;
		}

        // GET: api/Groupkpis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Targetlist>>> GetTargetLists()
        {
            return await _context.Targetlists.ToListAsync();
        }

        // GET: api/Groupkpis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Targetlist>> GetTargetList(int id)
        {
            var targetlist = await _context.Targetlists.FindAsync(id);

            if (targetlist == null)
            {
                return NotFound();
            }

            return targetlist;
        }

        // PUT: api/Groupkpis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Route("sua/{id}")]
        public async Task<IActionResult> PutTargetList(int id, Targetlist targetlist)
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
                if (!TargetListExists(id))
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
        public async Task<ActionResult<Targetlist>> PostTargetlist(Targetlist targetlist)
        {
            _context.Targetlists.Add(targetlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTargetlist", new { id = targetlist.Idtarget }, targetlist);
        }

        // DELETE: api/Groupkpis/5
        [HttpDelete("{id}")]
        [Route("xoa/{id}")]
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
        [HttpGet]
        [Route("getKpiFromEmployee/{idEmp}")]
        public async Task<List<Targetlist>> getKpiFromEmployee(int idEmp)
		{
            var lstkpi = await _context.Targetlists.Where(x => x.Idemployees == idEmp).ToListAsync();
            return lstkpi;
		}
        private bool TargetListExists(int id)
        {
            return _context.Targetlists.Any(e => e.Idtarget == id);
        }
    }
}
