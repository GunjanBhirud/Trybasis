using Microsoft.EntityFrameworkCore;

namespace AgriCulture.Models
{
    public class ContactUsContext : DbContext
    {
        public ContactUsContext(DbContextOptions<ContactUsContext> options) : base(options)
        {
        }

        public DbSet<ContactUs> ContactUss { get; set; }

    }
}
