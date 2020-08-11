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
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private readonly HaiGymContext _context;

        public AtletaController(HaiGymContext context)
        {
            _context = context;
        }

        // GET: api/GetListAtleti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atleta>>> GetListAtleti()
        {
            return await _context.Atleta.ToListAsync();
        }

        // GET: api/Atleta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atleta>> GetAtleta(string id)
        {
            var atleta = await _context.Atleta.FindAsync(id);

            if (atleta == null)
            {
                return NotFound();
            }

            return atleta;
        }

        // PUT: api/Atleta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtleta(string id, Atleta atleta)
        {
            if (id != atleta.IdAtleta)
            {
                return BadRequest();
            }

            _context.Entry(atleta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtletaExists(id))
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

        // POST: api/Atleta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Atleta>> PostAtleta(Atleta atleta)
        {
            _context.Atleta.Add(atleta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AtletaExists(atleta.IdAtleta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAtleta", new { id = atleta.IdAtleta }, atleta);
        }

        // DELETE: api/Atleta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Atleta>> DeleteAtleta(string id)
        {
            var atleta = await _context.Atleta.FindAsync(id);
            if (atleta == null)
            {
                return NotFound();
            }

            _context.Atleta.Remove(atleta);
            await _context.SaveChangesAsync();

            return atleta;
        }

        private bool AtletaExists(string id)
        {
            return _context.Atleta.Any(e => e.IdAtleta == id);
        }
    }
}
