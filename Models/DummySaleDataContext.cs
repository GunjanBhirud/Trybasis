using Microsoft.EntityFrameworkCore;

namespace Realestate.Models
{
    public class DummySaleDataContext : DbContext
    {
        public DummySaleDataContext(DbContextOptions<DummySaleDataContext> options) : base(options)
        {

        }
        public DbSet<DummySaleData> DummySaleDatas { get; set; }
    }
}
