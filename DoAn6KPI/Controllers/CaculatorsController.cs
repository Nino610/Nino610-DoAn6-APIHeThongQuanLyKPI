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
    public class CaculatorsController : ControllerBase
    {
        private readonly DoAnTNKPIContext _context;

        public CaculatorsController(DoAnTNKPIContext context)
        {
            _context = context;
        }

        // GET: api/Caculators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caculator>>> GetCaculators()
        {
            return await _context.Caculators.ToListAsync();
        }

        // GET: api/Caculators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caculator>> GetCaculator(int id)
        {
            var caculator = await _context.Caculators.FindAsync(id);

            if (caculator == null)
            {
                return NotFound();
            }

            return caculator;
        }

        // PUT: api/Caculators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaculator(int id, Caculator caculator)
        {
            if (id != caculator.Idcal)
            {
                return BadRequest();
            }

            _context.Entry(caculator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaculatorExists(id))
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

        // POST: api/Caculators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Caculator>> PostCaculator(Caculator caculator)
        {
            _context.Caculators.Add(caculator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaculator", new { id = caculator.Idcal }, caculator);
        }

        // DELETE: api/Caculators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Caculator>> DeleteCaculator(int id)
        {
            var caculator = await _context.Caculators.FindAsync(id);
            if (caculator == null)
            {
                return NotFound();
            }

            _context.Caculators.Remove(caculator);
            await _context.SaveChangesAsync();

            return caculator;
        }


        private bool CaculatorExists(int id)
        {
            return _context.Caculators.Any(e => e.Idcal == id);
        }
    }
}
