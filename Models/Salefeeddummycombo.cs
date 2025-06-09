namespace Realestate.Models
{
    public class Salefeeddummycombo
    {
        public SaleHome SaleHome {  get; set; }

        public Feedback Feedback { get; set; }
        
        public DummyFeedback DummyFeedback { get; set; }

       public IEnumerable<SaleHome> SaleHomes { get; set; }

        public IEnumerable<Feedback> Feedbacks { get; set; }

        public IEnumerable <DummyFeedback> DummyFeedbacks { get;set; }




    }
}
