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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<CommonResponse<IEnumerable<CategoryViewModel>>> GetAll()
        {
            return _mapper.Map<CommonResponse<IEnumerable<CategoryViewModel>>>(await _categoryService.GetAll());
        }

        [HttpGet]
        [Route("GetAllWithCount")]
        public async Task<CommonResponse<IEnumerable<CategoryViewModel>>> GetAllWithCount()
        {
            return _mapper.Map<CommonResponse<IEnumerable<CategoryViewModel>>>(await _categoryService.GetAllInclude(null));
        }

        [HttpPost]
        public async Task<CommonResponse<CategoryViewModel>> Add(CategoryViewModel category)
        {
            Category data = _mapper.Map<Category>(category);

            return _mapper.Map<CommonResponse<CategoryViewModel>>(await _categoryService.Add(data));
        }

        [HttpPut]
        public async Task<CommonResponse<CategoryViewModel>> Update(CategoryViewModel category)
        {
            Category data = _mapper.Map<Category>(category);

            return _mapper.Map<CommonResponse<CategoryViewModel>>(await _categoryService.Update(data));
        }

        [HttpDelete("{id:int}")]
        public async Task<CommonResponse<CategoryViewModel>> Delete(int id)
        {
            return _mapper.Map<CommonResponse<CategoryViewModel>>(await _categoryService.Delete(id));
        }  
    }
}