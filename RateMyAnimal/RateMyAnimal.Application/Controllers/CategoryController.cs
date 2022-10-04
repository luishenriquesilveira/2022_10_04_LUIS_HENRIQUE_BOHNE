using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RateMyAnimal.Application.ViewModels;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;

namespace RateMyAnimal.Application.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = _mapper.Map<CommonResponse<IEnumerable<CategoryViewModel>>>(await _categoryService.GetAll());

            return View("Index", response.Data);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Create Category";
            return View("EditCategory");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = _mapper.Map<CommonResponse<CategoryViewModel>>(await _categoryService.GetById(id));

            ViewBag.Title = "Edit Category";
            return View("EditCategory", response.Data);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = _mapper.Map<CommonResponse<CategoryViewModel>>(await _categoryService.Delete(id));

            if(response.Succeeded)
                return await Index();

            ViewBag.Error = response.Message;

            var r = _mapper.Map<CommonResponse<IEnumerable<CategoryViewModel>>>(await _categoryService.GetAll());
            return View("Index", r.Data);
        }

        public async Task<IActionResult> SaveCategory(CategoryViewModel category)
        {
            Category data = _mapper.Map<Category>(category);

            if (category.Id.HasValue)
                await _categoryService.Update(data);
            else
                await _categoryService.Add(data);

            return await Index();
        }
    }
}