using System.ComponentModel.DataAnnotations;

namespace RateMyAnimal.Application.ViewModels
{
    public class AnimalViewModel
    {
        public int? Id { get; set; }
        public string Image { get; set; }
        public DateTime? Date { get; set; }

        [MinLength(1, ErrorMessage = "The Categories field must have at least one category.")]
        [MaxLength(3, ErrorMessage = "The Categories field must have a maximum three categories.")]
        public IEnumerable<int> Categories { get; set; }
    }
}
