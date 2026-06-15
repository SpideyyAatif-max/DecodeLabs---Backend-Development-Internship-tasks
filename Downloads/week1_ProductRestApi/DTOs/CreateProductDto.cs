using System.ComponentModel.DataAnnotations;

namespace ProductRestApi.DTOs;

public class CreateProductDto
{
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Product description is required")]
    [StringLength(500, ErrorMessage = "Description cannot be more than 500 characters")]
    public string Description { get; set; } = string.Empty;

    [Range(1, 1000000, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    public bool InStock { get; set; } = true;
}
