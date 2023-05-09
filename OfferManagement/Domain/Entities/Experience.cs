namespace Domain.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string Name { get; set; }


        public IList<Offer> Offer { get; set; }
    }
}
