using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    public class Product_Category_MappingMap : EntityTypeConfiguration<Product_Category_Mapping>
    {
        public Product_Category_MappingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Product_Category_Mapping");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Product_Category_Mapping)
                .HasForeignKey(d => d.CategoryId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Product_Category_Mappings)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
