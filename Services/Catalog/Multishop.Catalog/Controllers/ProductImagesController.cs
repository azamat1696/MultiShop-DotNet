using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ProductImageDtos;
using Multishop.Catalog.Services.ProductImageServices;

namespace Multishop.Catalog.Controllers;
 [Route("api/[controller]")]
 [ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageService _productImageService;

    public ProductImagesController(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        var categories = await _productImageService.GetAllProductImageAsync();
        return Ok(categories);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var productImage = await _productImageService.GetByIdProductImageAsync(id);
        return Ok(productImage);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _productImageService.CreateProductImageAsync(createProductImageDto);
        return Ok("Ürün görseli başarıyla oluşturuldu");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _productImageService.DeleteProductImageAsync(id);
        return Ok("Ürün görseli silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _productImageService.UpdateProductImageAsync(updateProductImageDto);
        return Ok("Ürün görseli güncellendi");
    }
}