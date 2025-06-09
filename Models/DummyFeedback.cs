using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realestate.Models
{
    public class DummyFeedback
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Contact { get; set; }

        public string Message { get; set; }
        [NotMapped]
        public IFormFile Imgfeedback { get; set; }
    }
}
