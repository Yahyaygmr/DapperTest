using DapperTest.Services.Abstracts.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeStatisticsComponentPartial : ViewComponent
    {
        private readonly IStatisticsService statisticsService;

        public HomeStatisticsComponentPartial(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await statisticsService.GetStatisticsAsync();
            return View(values);
        }
    }
}
