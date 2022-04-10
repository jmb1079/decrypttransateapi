using DecryptTranslateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DecryptTranslateApi.Data {
    public class CaseContext : DbContext {
        public CaseContext(DbContextOptions<CaseContext> options)
            : base(options)
        {
        } 

        public DbSet<Case> Cases {get; set;} =null!;
    }
}