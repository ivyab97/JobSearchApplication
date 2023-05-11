namespace Aplication.DTO.Request
{
    public class OfferRequest
    {
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
        public int ExperienceId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int StudyLevelId { get; set; }

        public IList<int> Categories { get; set; }
    }
}
