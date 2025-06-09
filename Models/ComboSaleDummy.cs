namespace Realestate.Models
{
    public class ComboSaleDummy
    {
        public SaleHome SaleHome { get; set; }

        public DummySaleData DummySaleData { get; set; }

      

        public IEnumerable<SaleHome> SaleHomes { get; set; }

        public IEnumerable<DummySaleData> DummySaleDatas { get; set; }

       


    }
}
