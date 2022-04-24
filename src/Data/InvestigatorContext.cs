using DecryptTranslateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DecryptTranslateApi.Data {
    public class InvestigatorContext : DbContext {
        public InvestigatorContext(DbContextOptions<InvestigatorContext> options)
            : base(options)
        {
        } 

        public DbSet<Investigator> Investigators {get; set;} =null!;
    }
}