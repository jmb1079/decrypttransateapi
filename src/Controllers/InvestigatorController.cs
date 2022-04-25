using DecryptTranslateApi.Data;
using DecryptTranslateApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecryptTranslateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestigatorController : ControllerBase
    {
        private readonly InvestigatorContext _context;

        public InvestigatorController(InvestigatorContext context)
        {
            _context = context;
        }

        // GET: api/investigator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investigator>>> GetInvestigatorItems()
        {
            return await _context.Investigators.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Investigator>> GetInvestigator(string id)
        {
            Console.WriteLine(id);
            var investigator = await _context.Investigators.FindAsync(id);

            if (investigator == null)
            {
                return NotFound();
            }

            return investigator;
        }
    }
}