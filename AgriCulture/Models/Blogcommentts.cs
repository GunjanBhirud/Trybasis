using System.ComponentModel.DataAnnotations;

namespace AgriCulture.Models
{
    public class Blogcommentts
    {
        [Key]
        public int CommentId { get; set; }

        public int BlogId { get; set; } 
        public string Name { get; set; }

        public string Email { get; set; }
        public string Comment { get; set; }
        public DateOnly Date { get; set; }
        public string Location { get; set; }
    }
}
