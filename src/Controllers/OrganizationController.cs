using DecryptTranslateApi.Data;
using DecryptTranslateApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecryptTranslateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationContext _context;

        public OrganizationController(OrganizationContext context)
        {
            _context = context;
        }

        // GET: api/organization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizationItems()
        {
            return await _context.Organizations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganizationById(int id)
        {
            Console.WriteLine(id);
            var investigator = await _context.Organizations.FindAsync(id);

            if (investigator == null)
            {
                return NotFound();
            }

            return investigator;
        }
    }
}