using DapperTest.Dtos.CategoryDtos;
using DapperTest.Services.Abstracts.Category;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeSearchPropertyComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomeSearchPropertyComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.categories = await GetCategories();
            return View();
        }
        public async Task<List<ResultCategoryDto>> GetCategories()
        {
            return await _categoryService.GetAllCategoryAsync();
        }
    }
}
