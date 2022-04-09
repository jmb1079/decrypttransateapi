using Microsoft.EntityFrameworkCore;

namespace DecryptTranslateApi.Models {
    public class CaseContext : DbContext {
        public CaseContext(DbContextOptions<CaseContext> options)
            : base(options)
        {
        } 

        public DbSet<CaseItem> caseItems {get; set;} =null!;
    }
}