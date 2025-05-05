using System.ComponentModel.DataAnnotations;

namespace AgriCulture.Models
{
    public class AddBlogdummy
    {
        [Key]
        public int BlogId { get; set; }

        public string username { get; set; }
        public string email { get; set; }

        public string Profession { get; set; }
        public string type { get; set; }

        public IFormFile fileattached { get; set; }

        public DateTime Publisheddate { get; set; }= DateTime.Now;

        public string personal_data { get; set; }

        public string subject { get; set; }
        
        public string description { get; set; }
    }
}
