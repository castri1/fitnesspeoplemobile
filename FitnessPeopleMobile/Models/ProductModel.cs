using System.Collections.Generic;

namespace FitnessPeopleMobile.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            ProductAttributes = new List<ProductAttributesModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal VendorPrice { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Url { get; set; }
        public int DisplayOrder { get; set; }
        public List<ProductAttributesModel> ProductAttributes { get; set; }
    }

    public class ProductAttributesModel
    {
        public string Name { get; set; }
        public int StockQuantity { get; set; }
    }
}