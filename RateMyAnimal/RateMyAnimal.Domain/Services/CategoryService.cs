using FluentValidation.Results;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;
using RateMyAnimal.Domain.Helpers;
using RateMyAnimal.Domain.Validations;

namespace RateMyAnimal.Domain.Services
{
    public class CategoryService : Notificator, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CommonResponse<Category>> GetById(int id)
        {
            var response = await _categoryRepository.GetByIdInclude(id);

            if (response is null)
                return CommonResponse<Category>.FailNotFound(id);

            return CommonResponse<Category>.Success(response);
        }

        public async Task<CommonResponse<IEnumerable<Category>>> GetAll()
        {
            var response = await _categoryRepository.GetAll();

            if (!response.Any())
                return CommonResponse<IEnumerable<Category>>.FailEmpty();

            return CommonResponse<IEnumerable<Category>>.Success(response);
        }

        public async Task<CommonResponse<IEnumerable<Category>>> GetAllInclude(int? recordsNumber)
        {
            var response = await _categoryRepository.GetAllInclude(recordsNumber);

            if (!response.Any())
                return CommonResponse<IEnumerable<Category>>.FailEmpty();

            return CommonResponse<IEnumerable<Category>>.Success(response);
        }

        public async Task<CommonResponse<Category>> Add(Category category)
        {
            var validator = CategoryValidator(category);
            if (!validator.IsValid)
                return CommonResponse<Category>.FailValidation(Notify(validator));

            await _categoryRepository.Add(category);

            return CommonResponse<Category>.Success(category);
        }

        public async Task<CommonResponse<Category>> Update(Category category)
        {
            var response = await GetById(Convert.ToInt32(category.Id));
            if (!response.Succeeded)
                return response;

            var validator = CategoryValidator(category);
            if (!validator.IsValid)
                return CommonResponse<Category>.FailValidation(Notify(validator));

            Category categoryToUpdate = response.Data;
            categoryToUpdate.ChangeCategory(category);

            await _categoryRepository.Update(categoryToUpdate);

            return CommonResponse<Category>.Success(categoryToUpdate);
        }

        public async Task<CommonResponse<Category>> Delete(int id)
        {
            var response = await GetById(id);
            if (!response.Succeeded)
                return response;

            if(response.Data.AnimalCategories.Count() != 0)
                return CommonResponse<Category>.Fail("It is not possible to delete a category in use.");

            await _categoryRepository.Delete(response.Data);

            return CommonResponse<Category>.Success(response.Data);
        }

        private ValidationResult CategoryValidator(Category category)
        {
            return new CategoryValidator().Validate(category);
        }
    }
}
