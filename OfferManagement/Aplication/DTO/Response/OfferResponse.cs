namespace Aplication.DTO.Response
{
    public class OfferResponse
    {
        public Guid OfferId { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public ExperienceResponse Experience { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public StudyLevelResponse StudyLevel { get; set; }
        public string Date { get; set; }
        public IList<OfferCategoryResponse> Categories { get; set; }
    }
}
