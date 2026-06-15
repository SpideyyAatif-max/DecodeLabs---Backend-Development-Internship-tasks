using ProductRestApi.DTOs;
using ProductRestApi.Models;

namespace ProductRestApi.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Keyboard",
            Description = "Mechanical keyboard",
            Price = 50,
            InStock = true
        },
        new Product
        {
            Id = 2,
            Name = "Mouse",
            Description = "Wireless mouse",
            Price = 25,
            InStock = true
        }
    };

    private int _nextId = 3;

    public List<ProductResponseDto> GetAllProducts()
    {
        return _products.Select(MapToResponseDto).ToList();
    }

    public ProductResponseDto? GetProductById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return product is null ? null : MapToResponseDto(product);
    }

    public ProductResponseDto CreateProduct(CreateProductDto productDto)
    {
        var product = new Product
        {
            Id = _nextId++,
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            InStock = productDto.InStock
        };

        _products.Add(product);
        return MapToResponseDto(product);
    }

    private static ProductResponseDto MapToResponseDto(Product product)
    {
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            InStock = product.InStock
        };
    }
}
