using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RateMyAnimal.Domain.Interfaces;

namespace RateMyAnimal.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public HomeController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _categoryService.GetAllInclude(10);

            return View("Index", response.Data);
        }

        public IActionResult ComingSoon()
        {
            return View();
        }
    }
}