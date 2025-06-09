using Microsoft.EntityFrameworkCore;

namespace Realestate.Models
{
    public class CombomodelContext :DbContext
    {
        public CombomodelContext(DbContextOptions<CombomodelContext> options) : base(options)
        {

        }
        public DbSet<SaleHome> SaleHomes { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<DummyFeedback> DummyFeedbacks { get; set; }

       
    }
}
