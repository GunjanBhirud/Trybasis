using Microsoft.EntityFrameworkCore;

namespace Realestate.Models
{
    public class VerifySaledataContext : DbContext
    {
        public VerifySaledataContext(DbContextOptions<VerifySaledataContext> options) : base(options)
        {

        }
        public DbSet<VerifySaledata> VerifySaledatas { get; set; }
    }
}