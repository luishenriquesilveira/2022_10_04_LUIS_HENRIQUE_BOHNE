using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RateMyAnimal.Application.ViewModels;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;

namespace RateMyAnimal.Application.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalService animalService, ICategoryService categoryService, IMapper mapper)
        {
            _animalService = animalService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await GetRandomAnimal();

            ViewBag.Categories = await GetDllCategories();
            return View("Index", response.Data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.GetById(id));

            ViewBag.ReturnTo = "ZooList";
            ViewBag.Categories = await GetDllCategories();
            return View("Index", response.Data);
        }

        public async Task<IActionResult> CreateAnimal(AnimalViewModel animal)
        {
            Animal data = _mapper.Map<Animal>(animal);

            var response = _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.Add(data));

            ViewBag.Categories = await GetDllCategories();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAnimal(AnimalViewModel animal)
        {
            Animal data = _mapper.Map<Animal>(animal);

            var response = _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.Update(data));

            return RedirectToAction("ZooIndex");
        }

        public async Task<IActionResult> ZooIndex()
        {
            var response = await GetDllCategories();

            return View("ZooIndex", response);
        }

        public async Task<IActionResult> GetAll(int? categoryId)
        {
            if (categoryId.HasValue)
                return await GetAllByIdCategory((int)categoryId);

            var response = await _animalService.GetAll(null);

            return PartialView("_SearchZooPartial", response.Data);
        }
        public async Task<IActionResult> GetAllByIdCategory(int categoryId)
        {
            var response = await _animalService.GetAllByIdCategory((int)categoryId);

            return PartialView("_SearchZooPartial", response.Data);
        }

        private async Task<CommonResponse<AnimalViewModel>> GetRandomAnimal()
        {
            return _mapper.Map<CommonResponse<AnimalViewModel>>(await _animalService.GetRandomAnimalImage());
        }

        private async Task<IEnumerable<CategoryViewModel>> GetDllCategories()
        {
            var response = _mapper.Map<CommonResponse<IEnumerable<CategoryViewModel>>>(await _categoryService.GetAll());
            return response.Data;
        }
    }
}