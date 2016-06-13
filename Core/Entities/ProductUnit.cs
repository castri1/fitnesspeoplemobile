namespace Core.Entities
{
    public class ProductUnit
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductAttributes { get; set; }
        public int PvacId { get; set; }

        public virtual ProductVariantAttributeCombination ProductVariantAttributeCombination { get; set; }

    }
}
