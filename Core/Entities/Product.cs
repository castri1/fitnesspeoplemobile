using System.Collections.Generic;

namespace Core.Entities
{
    public class Product
    {
        public Product()
        {
            ProductVariantAttributeCombinations = new List<ProductVariantAttributeCombination>();
            Product_Category_Mappings = new List<Product_Category_Mapping>();
            ProductPictures = new List<ProductPicture>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal VendorPrice { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public virtual ICollection<ProductVariantAttributeCombination> ProductVariantAttributeCombinations { get; set; }
        public virtual ICollection<Product_Category_Mapping> Product_Category_Mappings { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
    }
}
