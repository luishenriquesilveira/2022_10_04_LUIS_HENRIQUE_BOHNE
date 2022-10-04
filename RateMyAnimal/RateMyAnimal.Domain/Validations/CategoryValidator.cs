using RateMyAnimal.Domain.Entities;
using FluentValidation;

namespace RateMyAnimal.Domain.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(v => v.Description)
                .NotNull().WithMessage("The Description field must not be null.")
                .NotEmpty().WithMessage("The Description field must not be empty.")
                .MinimumLength(3).WithMessage("The Description field must have at least 3 characters.")
                .MaximumLength(25).WithMessage("The Description field must have less than 25 characters.");
        }
    }
}
