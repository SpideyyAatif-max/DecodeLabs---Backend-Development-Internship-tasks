using Microsoft.AspNetCore.Mvc;
using ProductRestApi.Common;
using ProductRestApi.DTOs;
using ProductRestApi.Services;

namespace ProductRestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: /api/products
    [HttpGet]
    public ActionResult<ApiResponse<List<ProductResponseDto>>> GetAllProducts()
    {
        var products = _productService.GetAllProducts();
        return Ok(ApiResponse<List<ProductResponseDto>>.Ok(products, "Products retrieved successfully"));
    }

    // GET: /api/products/1
    [HttpGet("{id:int}")]
    public ActionResult<ApiResponse<ProductResponseDto>> GetProductById(int id)
    {
        var product = _productService.GetProductById(id);

        if (product is null)
        {
            return NotFound(ApiResponse<ProductResponseDto>.Fail("Product not found"));
        }

        return Ok(ApiResponse<ProductResponseDto>.Ok(product, "Product retrieved successfully"));
    }

    // POST: /api/products
    [HttpPost]
    public ActionResult<ApiResponse<ProductResponseDto>> CreateProduct([FromBody] CreateProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<object>.Fail("Invalid product data"));
        }

        var createdProduct = _productService.CreateProduct(productDto);

        return CreatedAtAction(
            nameof(GetProductById),
            new { id = createdProduct.Id },
            ApiResponse<ProductResponseDto>.Ok(createdProduct, "Product created successfully")
        );
    }
}
