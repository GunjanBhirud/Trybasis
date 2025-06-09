using Microsoft.EntityFrameworkCore;
using Realestate.Models;

namespace Realestate.Areas.Admin.Models
{
    public class Combineforjoin :DbContext
    {
        public Combineforjoin()
        {
        }

        public Combineforjoin(DbContextOptions<Combineforjoin> options) : base(options)
        {

        }
        public DbSet<SaleHome> SaleHomes { get; set; }

        public DbSet<VerifySaledata> VerifySaledatas { get; set; }

    }
}
