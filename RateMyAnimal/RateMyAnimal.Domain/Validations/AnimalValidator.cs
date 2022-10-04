using RateMyAnimal.Domain.Entities;
using FluentValidation;

namespace RateMyAnimal.Domain.Validations
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(v => v.Date)
                .NotNull().WithMessage("The Date field must not be null.")
                .NotEmpty().WithMessage("The Date field must not be empty.");

            RuleFor(v => v.AnimalCategories)
                .NotNull().WithMessage("The Categories field must not be null.")
                .NotEmpty().WithMessage("The Categories field must not be empty.")
                .Must(x => x.Count() > 0).WithMessage("The Categories field must have at least one category.")
                .Must(x => x.Count() < 4).WithMessage("The Categories field must have a maximum three categories.");
        }
    }
}
