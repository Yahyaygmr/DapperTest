using DapperTest.Dtos.TestimonialDtos;
using DapperTest.Services.Abstracts.Testimonial;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public AdminTestimonialController(ITestimonialService TestimonialService)
        {
            _testimonialService = TestimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            await _testimonialService.CreateTestimonialAsync(dto);
            return RedirectToAction("TestimonialList");
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var values = await _testimonialService.GetTestimonialAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            await _testimonialService.UpdateTestimonialAsync(dto);
            return RedirectToAction("TestimonialList");
        }
    }
}
