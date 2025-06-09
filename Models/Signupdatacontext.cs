using Microsoft.EntityFrameworkCore;

namespace Realestate.Models
{
    public class Signupdatacontext : DbContext
    { 
        public Signupdatacontext(DbContextOptions<Signupdatacontext> options):base(options) 
        { 
        
        }

        public DbSet<Signupdata>Signupdatas { get; set; }
    }
}
