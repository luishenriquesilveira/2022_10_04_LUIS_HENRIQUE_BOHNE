using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RateMyAnimal.Api.ViewModels;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;

namespace RateMyAnimal.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalService animalService, IMapper mapper)
        {
            _animalService = animalService;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<CommonResponse<AnimalViewModel>> GetById(int id)
        {
            return _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.GetById(id));
        }

        [HttpGet]
        [Route("GetHistory/{recordsNumber?}")]
        public async Task<CommonResponse<IEnumerable<AnimalViewModel>>> GetAll(int? recordsNumber)
        {
            return _mapper.Map<CommonResponse<IEnumerable<AnimalViewModel>>>(await _animalService.GetAll(recordsNumber));
        }

        [HttpGet]
        [Route("GetByCategory/{id}")]
        public async Task<CommonResponse<IEnumerable<AnimalViewModel>>> GetAllByIdCategory(int id)
        {
            return _mapper.Map<CommonResponse<IEnumerable<AnimalViewModel>>>(await _animalService.GetAllByIdCategory(id));
        }

        [HttpPost]
        public async Task<CommonResponse<AnimalViewModel>> Add(AnimalViewModel animal)
        {
            //excluir
            var animalImg = await GetRandomAnimal();
            animal.Image = animalImg.Data.Image;
            //excluir

            Animal data = _mapper.Map<Animal>(animal);

            return _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.Add(data));
        }

        [HttpPut]
        public async Task<CommonResponse<AnimalViewModel>> Update(AnimalViewModel animal)
        {
            //excluir
            var animalImg = await GetRandomAnimal();
            animal.Image = animalImg.Data.Image;
            //excluir

            Animal data = _mapper.Map<Animal>(animal);

            return _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.Update(data));
        }

        [HttpDelete("{id:int}")]
        public async Task<CommonResponse<AnimalViewModel>> Delete(int id)
        {
            return _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.Delete(id));
        }

        [HttpGet]
        [Route("GetRandomAnimal")]
        public async Task<CommonResponse<AnimalViewModel>> GetRandomAnimal()
        {
            return _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.GetRandomAnimalImage());
        }   
    }
}