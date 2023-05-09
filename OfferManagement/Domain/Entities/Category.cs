﻿namespace Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public IList<OfferCategory> OfferCategory { get; set; }
    }
}
