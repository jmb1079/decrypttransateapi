using DecryptTranslateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DecryptTranslateApi.Data {
    public class ImageContext : DbContext {
        public ImageContext(DbContextOptions<ImageContext> options)
            : base(options)
        {
        } 

        public DbSet<Image> Images {get; set;} =null!;
    }
}