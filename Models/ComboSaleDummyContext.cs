using Microsoft.EntityFrameworkCore;

namespace Realestate.Models
{
    public class ComboSaleDummyContext : DbContext
    {
        public ComboSaleDummyContext(DbContextOptions<ComboSaleDummyContext> options) : base(options)
        {

        }
        public DbSet<SaleHome> SaleHomes { get; set; }

        public DbSet<DummySaleData> DummySaleDatas { get; set; }

       


    }
}
