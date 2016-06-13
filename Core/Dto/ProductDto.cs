namespace Core.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal VendorPrice { get; set; }
        public string Picture { get; set; }
        public int DisplayOrder { get; set; }
    }
}
