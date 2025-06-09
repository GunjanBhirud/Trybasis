using System.ComponentModel.DataAnnotations;

namespace Realestate.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string AdminName { get; set; }

        public string AdminPhone { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }

        public string AdminPassConfirm { get; set;}


    }
}
