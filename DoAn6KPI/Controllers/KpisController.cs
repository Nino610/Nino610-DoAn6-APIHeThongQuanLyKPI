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
    public class KpisController : ControllerBase
    {
        private readonly DoAnTNKPIContext _context;

        public KpisController(DoAnTNKPIContext context)
        {
            _context = context;
        }

        // GET: api/Kpis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kpi>>> GetKpis()
        {
            return await _context.Kpis.ToListAsync();
        }

        // GET: api/Kpis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kpi>> GetKpi(int id)
        {
            var kpi = await _context.Kpis.FindAsync(id);

            if (kpi == null)
            {
                return NotFound();
            }

            return kpi;
        }

        // PUT: api/Kpis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Route("sua/{id}")]
        public async Task<IActionResult> PutKpi(int id, Kpi kpi)
        {
            if (id != kpi.Idkpi)
            {
                return BadRequest();
            }

            _context.Entry(kpi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KpiExists(id))
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

        // POST: api/Kpis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("them")]
        public async Task<ActionResult<Kpi>> PostKpi(Kpi kpi)
        {
            _context.Kpis.Add(kpi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KpiExists(kpi.Idkpi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKpi", new { id = kpi.Idkpi }, kpi);
        }

        // DELETE: api/Kpis/5
        [HttpDelete("{id}")]
        [Route("xoa/{id}")]
        public async Task<ActionResult<Kpi>> DeleteKpi(int id)
        {
            var kpi = await _context.Kpis.FindAsync(id);
            if (kpi == null)
            {
                return NotFound();
            }

            _context.Kpis.Remove(kpi);
            await _context.SaveChangesAsync();

            return kpi;
        }
        [HttpGet]
        [Route("get/{idGroupKpi}")]
        public async Task<List<Kpi>> getListFromIdGroup(int idGroupKpi)
        {
            var listKpi = await _context.Kpis.Where(x => x.Idgroupkpi == idGroupKpi).ToListAsync();
            return listKpi;
        }
        [HttpGet]
        [Route("getFromName/{nameKpi}")]
        public async Task<List<Kpi>> getListFromIdGroup(string nameKpi)
        {
            var listKpi = await _context.Kpis.Where(x => x.Namekpi == nameKpi).ToListAsync();
            return listKpi;
        }
        private bool KpiExists(int id)
        {
            return _context.Kpis.Any(e => e.Idkpi == id);
        }
    }
}
