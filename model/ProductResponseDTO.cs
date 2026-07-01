namespace ProductManagement.DTOs
{
    public class ProductResponseDTO
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Brand { get; set; }

        public string SKU { get; set; }
    }
}