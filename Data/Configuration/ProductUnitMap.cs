using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    public class ProductUnitMap : EntityTypeConfiguration<ProductUnit>
    {
        public ProductUnitMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired();

            this.Property(t => t.ProductAttributes)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ProductUnit");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.ProductAttributes).HasColumnName("ProductAttributes");
            this.Property(t => t.PvacId).HasColumnName("PvacId");

            // Relationships
            this.HasRequired(t => t.ProductVariantAttributeCombination)
                .WithMany(t => t.ProductUnits)
                .HasForeignKey(d => d.PvacId);

        }
    }
}
