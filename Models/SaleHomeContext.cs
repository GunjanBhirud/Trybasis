using Microsoft.EntityFrameworkCore;

namespace Realestate.Models
{
    public class SaleHomeContext : DbContext
    {
        public SaleHomeContext(DbContextOptions<SaleHomeContext> options) : base(options)
        {

        }
        public DbSet<SaleHome> SaleHomes { get; set; }

    }
}
