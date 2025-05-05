using Microsoft.EntityFrameworkCore;

namespace AgriCulture.Models
{
    public class BlogcommentContext : DbContext
    {
        public BlogcommentContext(DbContextOptions<BlogcommentContext> options) : base(options)
        {
        }

        public DbSet<Blogcommentts> Blogcommentts { get; set; }
    }
}
