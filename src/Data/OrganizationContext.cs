using DecryptTranslateApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DecryptTranslateApi.Data {
    public class OrganizationContext : DbContext {
        public OrganizationContext(DbContextOptions<OrganizationContext> options)
            : base(options)
        {
        } 

        public DbSet<Organization> Organizations {get; set;} =null!;
    }
}