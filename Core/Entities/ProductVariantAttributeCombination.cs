using System.Collections.Generic;

namespace Core.Entities
{
    public class ProductVariantAttributeCombination
    {
        public ProductVariantAttributeCombination()
        {
            ProductUnits = new List<ProductUnit>();
        }

        public int Id { get; set; }
        public int StockQuantity { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<ProductUnit> ProductUnits { get; set; }
    }
}
