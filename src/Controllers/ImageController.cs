using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
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
        private readonly IConfiguration _configuration;

        public ImageController(ImageContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        [HttpPost("blob")]
        public async Task<String> UploadBlob(ImageUploadDto imageUpload)
        {
            var serviceClient = new BlobServiceClient(new Uri(_configuration.GetValue<string>("ConnectionString:StorageAccount")));
            var containerClient = serviceClient.GetBlobContainerClient(imageUpload.ContainerName);
            //create new filename to ensure uniqueness
            Guid guid = new Guid();
            string blobName = String.Format("{0}_{1}", guid, imageUpload.FileName);
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(imageUpload.Content, false);
            Image image = new Image
            {
                Guid = guid,
                Container = imageUpload.ContainerName,
                Case = imageUpload.CaseNumber
            };
            await PostImageItem(image);
            return blobName;
        }

        [HttpGet("blob")]
        public async Task<BinaryData> GetBlob(string containerName, string fileName)
        {
            var serviceClient = new BlobServiceClient(new Uri(_configuration.GetValue<string>("ConnnectionString:StorageAccount")));
            var containerClient = serviceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            var blob = await blobClient.DownloadContentAsync();
            return blob.Value.Content;
        }
    }
}