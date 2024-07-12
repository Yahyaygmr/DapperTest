using DapperTest.Dtos.TestimonialDtos;

namespace DapperTest.Services.Abstracts.Testimonial
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto dto);
        Task DeleteTestimonialAsync(int id);
        Task UpdateTestimonialAsync(UpdateTestimonialDto dto);
        Task<GetByIdTestimonialDto> GetTestimonialAsync(int id);
    }
}
