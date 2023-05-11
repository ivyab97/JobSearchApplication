namespace Aplication.DTO.Request
{
    public class OfferCategoryRequest
    {
        public Guid OfferId { get; set; }
        public IList<int> Categories { get; set; }
    }
}
