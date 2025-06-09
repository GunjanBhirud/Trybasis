using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realestate.Models
{
    public class DummySaleData
    {
        [Key]
        public int SaleId { get; set; }

        public string Sale_Person_Name { get; set; }

        public string Sale_Person_Email { get; set; }
        public string Sale_Person_Number { get; set; }
        public string Property_Type { get; set; }
        public long Property_Value { get; set; }
        public string Property_Address { get; set; }
        public string Property_City { get; set; }
        [NotMapped]
        public IFormFile Property_Imagee { get; set; }
    }
}
