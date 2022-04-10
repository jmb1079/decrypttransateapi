#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DecryptTranslateApi.Data;
using DecryptTranslateApi.Models;

namespace DecryptTranslateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly CaseContext _context;

        public CaseController(CaseContext context)
        {
            _context = context;
        }

        // GET: api/Case
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Case>>> GetcaseItems()
        {
            return await _context.Cases.ToListAsync();
        }

        // GET: api/Case/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Case>> GetCaseItem(int id)
        {
            var caseItem = await _context.Cases.FindAsync(id);

            if (caseItem == null)
            {
                return NotFound();
            }

            return caseItem;
        }

        // PUT: api/Case/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseItem(int id, Case caseItem)
        {
            if (id != caseItem.Number)
            {
                return BadRequest();
            }

            _context.Entry(caseItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseItemExists(id))
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

        // POST: api/Case
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Case>> PostCaseItem(Case caseItem)
        {
            _context.Cases.Add(caseItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCaseItem), new { id = caseItem.Number }, caseItem);
        }

        // DELETE: api/Case/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseItem(int id)
        {
            var caseItem = await _context.Cases.FindAsync(id);
            if (caseItem == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(caseItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseItemExists(int id)
        {
            return _context.Cases.Any(e => e.Number == id);
        }
    }
}
