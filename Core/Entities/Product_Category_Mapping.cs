namespace Core.Entities
{
    public partial class Product_Category_Mapping
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
