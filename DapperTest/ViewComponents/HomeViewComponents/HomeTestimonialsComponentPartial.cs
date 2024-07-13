using DapperTest.Services.Abstracts.Testimonial;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.ViewComponents.HomeViewComponents
{
    public class HomeTestimonialsComponentPartial : ViewComponent
    {
       private readonly ITestimonialService testimonialService;

		public HomeTestimonialsComponentPartial(ITestimonialService testimonialService)
		{
			this.testimonialService = testimonialService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await testimonialService.GetAllTestimonialAsync();
            return View(values);
        }
    }
}
