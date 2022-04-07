#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LatihanAPI.Models;

namespace LatihanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KotaController : ControllerBase
    {
        private readonly Db_SelfContext _context;

        public KotaController(Db_SelfContext context)
        {
            _context = context;
        }

        // GET: api/Kota
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterKotum>>> GetMasterKota()
        {
            return await _context.MasterKota.OrderBy(ss => ss.IdKota).ToListAsync();
        }

        // GET: api/Kota/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterKotum>> GetMasterKotum(int id)
        {
            var masterKotum = await _context.MasterKota.FindAsync(id);

            if (masterKotum == null)
            {
                return NotFound();
            }

            return masterKotum;
        }

        // PUT: api/Kota/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterKotum(int id, MasterKotum masterKotum)
        {
            if (id != masterKotum.IdKota)
            {
                return BadRequest();
            }

            _context.Entry(masterKotum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterKotumExists(id))
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

        // POST: api/Kota
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MasterKotum>> PostMasterKotum(MasterKotum masterKotum)
        {
            _context.MasterKota.Add(masterKotum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MasterKotumExists(masterKotum.IdKota))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMasterKotum", new { id = masterKotum.IdKota }, masterKotum);
        }

        // DELETE: api/Kota/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterKotum(int id)
        {
            var masterKotum = await _context.MasterKota.FindAsync(id);
            if (masterKotum == null)
            {
                return NotFound();
            }

            _context.MasterKota.Remove(masterKotum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterKotumExists(int id)
        {
            return _context.MasterKota.Any(e => e.IdKota == id);
        }
    }
}
