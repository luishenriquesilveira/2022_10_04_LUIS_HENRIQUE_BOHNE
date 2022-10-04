using System.ComponentModel.DataAnnotations;

namespace RateMyAnimal.Application.ViewModels
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }

        [MinLength(3, ErrorMessage = "The Description field must have at least 3 characters.")]
        [MaxLength(25, ErrorMessage = "The Description field must have less than 25 characters.")]
        public string Description { get; set; }
        public IEnumerable<AnimalCategoryViewModel> AnimalCategories { get; set; }
    }
}
