using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HayGym_API.Models;

namespace HayGym_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchedaController : ControllerBase
    {
        private readonly HaiGymContext _context;

        public SchedaController(HaiGymContext context)
        {
            _context = context;
        }

        // GET: api/Scheda/GetListSchede
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scheda>>> GetListSchede()
        {
            return await _context.Scheda.ToListAsync();
        }

        // GET: api/Scheda/GetScheda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scheda>> GetScheda(int id)
        {
            var scheda = await _context.Scheda.FindAsync(id);

            if (scheda == null)
            {
                return NotFound();
            }

            return scheda;
        }

        // POST: api/Scheda/AddScheda
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Scheda>> AddScheda(Scheda scheda)
        {
            _context.Scheda.Add(scheda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheda", new { id = scheda.IdScheda }, scheda);
        }

        // PUT: api/Scheda/Update/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScheda(int id, Scheda scheda)
        {
            if (id != scheda.IdScheda)
            {
                return BadRequest();
            }

            _context.Entry(scheda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchedaExists(id))
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


        // DELETE: api/Scheda/DeleteScheda/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scheda>> DeleteScheda(int id)
        {
            var scheda = await _context.Scheda.FindAsync(id);
            if (scheda == null)
            {
                return NotFound();
            }

            _context.Scheda.Remove(scheda);
            await _context.SaveChangesAsync();

            return scheda;
        }

        private bool SchedaExists(int id)
        {
            return _context.Scheda.Any(e => e.IdScheda == id);
        }
    }
}
