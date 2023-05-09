namespace Domain.Entities
{
    public class StudyLevel
    {
        public int StudyLevelId { get; set; }
        public string Name { get; set; }

        public IList<Offer> Offer { get; set; }
    }
}
