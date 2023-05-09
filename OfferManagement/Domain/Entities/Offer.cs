namespace Domain.Entities
{
    public class Offer
    {
        public Guid OfferId { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public int ExperienceId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int StudyLevelId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }


        public StudyLevel StudyLevel { get; set; }
        public Experience Experience { get; set; }
        public IList<OfferCategory> OfferCategory { get; set; }
        public IList<Application> Application { get; set; }
    }
}
