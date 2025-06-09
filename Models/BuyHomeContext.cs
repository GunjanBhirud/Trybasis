using Microsoft.EntityFrameworkCore;

namespace Realestate.Models
{
    public class BuyHomeContext : DbContext
    {
        public BuyHomeContext(DbContextOptions<BuyHomeContext> options) : base(options)
        {

        }
        public DbSet<BuyHome> BuyHomes { get; set; }
    }
}
