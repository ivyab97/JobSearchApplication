namespace Domain.Entities
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int ApplicationStatusTypeId { get; set; }
        public int ApplicantId { get; set; }
        public Guid OfferId { get; set; }
        public DateTime Date { get; set; }

        public bool Status { get; set; }

        public Offer Offer { get; set; }
        public ApplicationStatusType ApplicationStatusType { get; set; }
    }
}
