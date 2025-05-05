using System.ComponentModel.DataAnnotations;

namespace AgriCulture.Models
{
    public class ContactUs
    {
        [Key]
       public int ContactId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
