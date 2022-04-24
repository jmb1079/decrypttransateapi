using DecryptTranslateApi.Data;
using DecryptTranslateApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecryptTranslateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageContext _context;

        public ImageController(ImageContext context)
        {
            _context = context;
        }

        // GET: api/Image
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImageItems()
        {
            return await _context.Images.ToListAsync();
        }

        // POST: api/Image
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Image>> PostImageItem(Image imageItem)
        {
            _context.Images.Add(imageItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetImageItems), new { id = imageItem.Guid }, imageItem);
        }
    }
}