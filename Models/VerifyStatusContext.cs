using Microsoft.EntityFrameworkCore;

namespace Realestate.Models
{
    public class VerifyStatusContext : DbContext
    {
        public VerifyStatusContext(DbContextOptions<VerifyStatusContext> options) : base(options)
        {

        }
        public DbSet<VerifyStatus> VerifyStatuss { get; set; }
    }
}
