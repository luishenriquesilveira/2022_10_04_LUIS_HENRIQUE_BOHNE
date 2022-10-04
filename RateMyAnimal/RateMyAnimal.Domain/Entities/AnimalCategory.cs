using RateMyAnimal.Domain.Entities;

namespace RateMyAnimal.Domain.Entities
{
    public class AnimalCategory
    {
        public int AnimalId { get; set; }
        public int CategoryId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Category Category { get; set; }
    }
}
