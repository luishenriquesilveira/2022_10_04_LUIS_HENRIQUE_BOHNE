namespace RateMyAnimal.Api.ViewModels
{
    public class AnimalViewModel
    {
        public int? Id { get; set; }
        public string Image { get; set; }
        public DateTime? Date { get; set; }
        public IEnumerable<AnimalCategoryViewModel> Categories { get; set; }
    }
}
