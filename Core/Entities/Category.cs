using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Category
    {
        public Category()
        {
            this.Product_Category_Mapping = new List<Product_Category_Mapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public virtual ICollection<Product_Category_Mapping> Product_Category_Mapping { get; set; }
    }
}
