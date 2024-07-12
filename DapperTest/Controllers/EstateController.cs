using DapperTest.Dtos.CategoryDtos;
using DapperTest.Dtos.EstateDtos;
using DapperTest.Services.Abstracts.Category;
using DapperTest.Services.Abstracts.Estate;
using DapperTest.Services.Paginate;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateService _estateService;

        public EstateController(IEstateService estateService)
        {
            _estateService = estateService;
        }

        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            int pageSize = 4;
            var values = await _estateService.GetAllEstateWithCategoryAndLocationAsync();
            var paginatedList = await PaginatedList<ResultEstateWithCategoryAndLocationDto>.CreateAsync(values, pageIndex, pageSize);

            return View(paginatedList);
        }
        public IActionResult Detail(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SearchEstates(SearchEstateDto dto)
        {
            if (dto.ForRent == false && dto.ForSale == false)
            {
                dto.ForSale = true;
            }
            var values = await _estateService.Search(dto);
            return View(values);
        }

    }
}
