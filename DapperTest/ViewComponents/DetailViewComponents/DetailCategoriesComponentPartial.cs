using DapperTest.Services.Abstracts.Category;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.DetailViewComponents
{
    public class DetailCategoriesComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public DetailCategoriesComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryWithCountAsync();
            return View(values);
        }
       
    }
}
