using DapperTest.Dtos.ImageDtos;

namespace DapperTest.Dtos.EstateDtos
{
    public class CreateEstateDto
    {
        public string EstateName { get; set; }
        public string? VideoUrl { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public bool ForRent { get; set; }
        public bool ForSale { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public decimal Price { get; set; }
        public int AreaSize { get; set; }
        public bool IsFeatured { get; set; }
        public int BuildAge { get; set; }
        public List<string> Images { get; set; } = new List<string>();

        public int LocationId { get; set; }
        public int CategoryId { get; set; }
    }
}
