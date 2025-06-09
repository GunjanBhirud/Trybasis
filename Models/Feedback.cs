using System.ComponentModel.DataAnnotations;

namespace Realestate.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Contact { get; set; }

        public string Message { get; set; }

        public string Picfeedback { get; set; }

    }
}
