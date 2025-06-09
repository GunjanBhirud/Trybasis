using System.ComponentModel.DataAnnotations;

namespace Realestate.Models
{
    public class Signupdata
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; } 

        public string lastName { get; set; }

        public string email { get; set; }

        public string number { get; set; }
        public string password { get; set; } = null;

        public string cpassword { get; set; } = null;
    }
}
