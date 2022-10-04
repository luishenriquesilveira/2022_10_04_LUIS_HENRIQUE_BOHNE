namespace RateMyAnimal.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<AnimalCategory> AnimalCategories { get; set; }

        public void ChangeCategory(Category category)
        {
            Description = category.Description;
        }

        public Category(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
