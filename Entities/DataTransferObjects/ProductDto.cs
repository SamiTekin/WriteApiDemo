namespace Entities.DataTransferObjects
{
    public record ProductDto()
    {   
        public int Id { get; init; }
        public string ProductName { get; init; }
        public string ProductDescription { get; init; }
        public decimal ProductPrice { get; init; }
        public bool ProductType { get; init; }
    }
}
