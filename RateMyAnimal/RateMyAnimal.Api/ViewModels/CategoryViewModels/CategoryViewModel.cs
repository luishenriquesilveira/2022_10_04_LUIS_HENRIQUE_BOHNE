namespace RateMyAnimal.Api.ViewModels
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<AnimalCategoryViewModel>? Animals { get; set; }
    }
}
