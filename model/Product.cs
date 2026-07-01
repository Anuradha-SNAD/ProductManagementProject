using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 100000)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 10000)]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "SKU is required.")]
        public string SKU { get; set; }

    }
}
