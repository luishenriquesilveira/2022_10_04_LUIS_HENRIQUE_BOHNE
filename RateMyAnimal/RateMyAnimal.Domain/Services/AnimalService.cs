using FluentValidation.Results;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Enum;
using RateMyAnimal.Domain.Helpers;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;
using RateMyAnimal.Domain.Validations;

namespace RateMyAnimal.Domain.Services
{
    public class AnimalService : Notificator, IAnimalService
    {
        private static readonly Random rdn = new Random();

        private readonly IRandomAnimalService _catAsService;
        private readonly IRandomAnimalService _placeDogService;
        private readonly IRandomAnimalService _ShibeOnlineService;
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(Func<ServiceEnum, IRandomAnimalService> serviceResolver, IAnimalRepository animalRepository)
        {
            _catAsService = serviceResolver(ServiceEnum.CatAs);
            _placeDogService = serviceResolver(ServiceEnum.PlaceDog);
            _ShibeOnlineService = serviceResolver(ServiceEnum.ShibeOnline);
            _animalRepository = animalRepository;
        }

        public async Task<CommonResponse<Animal>> GetById(int id)
        {
            var response = await _animalRepository.GetByIdInclude(id);

            if (response is null)
                return CommonResponse<Animal>.FailNotFound(id);

            return CommonResponse<Animal>.Success(response);
        }

        public async Task<CommonResponse<IEnumerable<Animal>>> GetAll(int? recordsNumber)
        {
            var response = await _animalRepository.GetAllInclude(recordsNumber);

            if (!response.Any())
                return CommonResponse<IEnumerable<Animal>>.FailEmpty();

            return CommonResponse<IEnumerable<Animal>>.Success(response);
        }

        public async Task<CommonResponse<IEnumerable<Animal>>> GetAllByIdCategory(int id)
        {
            var response = await _animalRepository.GetAllByIdCategory(id);

            if (!response.Any())
                return CommonResponse<IEnumerable<Animal>>.FailEmpty();

            return CommonResponse<IEnumerable<Animal>>.Success(response);
        }

        public async Task<CommonResponse<Animal>> Add(Animal animal)
        {
            var validator = AnimalValidator(animal);
            if (!validator.IsValid)
                return CommonResponse<Animal>.FailValidation(Notify(validator));

            await _animalRepository.Add(animal);

            return CommonResponse<Animal>.Success(animal);
        }

        public async Task<CommonResponse<Animal>> Update(Animal animal)
        {
            var response = await GetById(Convert.ToInt32(animal.Id));
            if (!response.Succeeded)
                return response;

            var validator = AnimalValidator(animal);
            if (!validator.IsValid)
                return CommonResponse<Animal>.FailValidation(Notify(validator));

            Animal animalToUpdate = response.Data;
            animalToUpdate.ChangeAnimal(animal);

            await _animalRepository.Update(animalToUpdate);

            return CommonResponse<Animal>.Success(animalToUpdate);
        }

        public async Task<CommonResponse<Animal>> Delete(int id)
        {
            var response = await GetById(id);
            if (!response.Succeeded)
                return response;

            await _animalRepository.Delete(response.Data);

            return CommonResponse<Animal>.Success(response.Data);
        }

        public async Task<CommonResponse<Animal>> GetRandomAnimalImage()
        {
            CommonResponse<Animal> response = new CommonResponse<Animal>();

            Array values = typeof(ServiceEnum).GetEnumValues();
            int index = rdn.Next(values.Length);
            ServiceEnum value = (ServiceEnum)values.GetValue(index);

            switch (value)
            {
                case ServiceEnum.CatAs:
                    response = await _catAsService.GetRandomAnimal();
                    break;
                case ServiceEnum.PlaceDog:
                    response = await _placeDogService.GetRandomAnimal();
                    break;
                case ServiceEnum.ShibeOnline:
                    response = await _ShibeOnlineService.GetRandomAnimal();
                    break;
            }

            return response;
        }

        private ValidationResult AnimalValidator(Animal animal)
        {
            return new AnimalValidator().Validate(animal);
        }
    }
}
