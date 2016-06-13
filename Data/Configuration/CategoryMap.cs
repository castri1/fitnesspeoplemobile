using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasKey(i => i.Id);
            ToTable("Category");
        }
    }
}
