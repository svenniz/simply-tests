namespace ProductApi.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
    }
}
