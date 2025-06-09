using System.ComponentModel.DataAnnotations;

namespace Realestate.Models
{
    public class SaleHome
    {

        [Key]
        public int SaleId { get; set; }

        public string Sale_Person_Name { get; set; }

        public string Sale_Person_Email { get; set; }
        public string Sale_Person_Number { get; set; }
        public string Property_Type { get; set; }
        public long Property_Value { get; set;}
        public string Property_Address { get; set; }
        public string Property_City { get; set;}
        public string Property_Image { get; set;}




    }
}
