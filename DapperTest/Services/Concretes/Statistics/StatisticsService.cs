using DapperTest.Context;
using DapperTest.Dtos.StatisticDtos;
using DapperTest.Services.Abstracts.Agent;
using DapperTest.Services.Abstracts.Estate;
using DapperTest.Services.Abstracts.Statistics;
using DapperTest.Services.Abstracts.Testimonial;

namespace DapperTest.Services.Concretes.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IEstateService _estateService;
        private readonly IAgentService _agentService;
        private readonly ITestimonialService _testimonialService;

        public StatisticsService(IEstateService estateService, IAgentService agentService, ITestimonialService testimonialService)
        {
            _estateService = estateService;
            _agentService = agentService;
            _testimonialService = testimonialService;
        }

        public async Task<StatisticsDto> GetStatisticsAsync()
        {
            var estates = await _estateService.GetAllEstateAsync();
            var agents = await _agentService.GetAllAgentAsync();
            var testimonials = await _testimonialService.GetAllTestimonialAsync();

            StatisticsDto statistics = new StatisticsDto()
            {
                AgentCount = agents.Count,
                TestimonialCount = testimonials.Count,
                EstateCount = estates.Count,
                EstatesForRent = estates.Where(x => x.ForRent == true).ToList().Count(),
                EstatesForSale = estates.Where(x => x.ForSale == true).ToList().Count(),
            };
            return statistics;
        }
    }
}
