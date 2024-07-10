namespace DapperTest.Dtos.EstateDtos
{
    public class SearchEstateDto
    {
        public int? CategoryId { get; set; }
        public bool? ForRent { get; set; }
        public bool? ForSale { get; set; }
        public int? MinBedroomCount { get; set; }
        public int? MinBathroomCount { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinAreaSize { get; set; }
        public int? MaxAreaSize { get; set; }

    }
}
