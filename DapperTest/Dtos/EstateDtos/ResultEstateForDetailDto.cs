using DapperTest.Dtos.TagCloud;
using Microsoft.Build.Execution;

namespace DapperTest.Dtos.EstateDtos
{
    public class ResultEstateForDetailDto
    {
        public int EstateId { get; set; }
        public string EstateName { get; set; }
        public string Adress { get; set; }
        public bool ForRent { get; set; }
        public bool ForSale { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public decimal Price { get; set; }
        public int AreaSize { get; set; }
        public bool IsFeatured { get; set; }
        public int BuildAge { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }

        public List<ResultTagCloudDto> TagClouds { get; set; }
        public string LocationName { get; set; }
        public string CategoryName { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
    }
}
