using Microsoft.EntityFrameworkCore;

namespace AgriCulture.Models
{
    public class AddBlogContext :DbContext
    {
        public AddBlogContext(DbContextOptions<AddBlogContext> options) : base(options)
        {
        }

        public DbSet<AddBlog> AddBlogs { get; set; }
    }
}
