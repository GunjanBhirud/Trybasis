using Microsoft.EntityFrameworkCore;

namespace AgriCulture.Models
{
    public class UserregistrationContext : DbContext
    {
        public UserregistrationContext(DbContextOptions<UserregistrationContext> options) : base(options)
        {
        }

        public DbSet<Userregistration> Userregistrations { get; set; }
    }
}
