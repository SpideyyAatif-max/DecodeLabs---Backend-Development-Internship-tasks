using ProductRestApi.DTOs;

namespace ProductRestApi.Services;

public interface IProductService
{
    List<ProductResponseDto> GetAllProducts();
    ProductResponseDto? GetProductById(int id);
    ProductResponseDto CreateProduct(CreateProductDto productDto);
}
