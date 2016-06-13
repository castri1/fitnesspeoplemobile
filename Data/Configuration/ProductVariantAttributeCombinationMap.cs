using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    public partial class ProductVariantAttributeCombinationMap : EntityTypeConfiguration<ProductVariantAttributeCombination>
    {
        public ProductVariantAttributeCombinationMap()
        {
            this.ToTable("ProductVariantAttributeCombination");
            this.HasKey(pvac => pvac.Id);

            this.HasRequired(pvac => pvac.Product)
                .WithMany(p => p.ProductVariantAttributeCombinations)
                .HasForeignKey(pvac => pvac.ProductId);
        }
    }
}
