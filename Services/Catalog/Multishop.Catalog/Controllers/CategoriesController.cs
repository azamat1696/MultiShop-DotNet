using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Services.CategoryServices;

namespace Multishop.Catalog.Controllers;
 [Route("api/[controller]")]
 [ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var categories = await _categoryService.GetAllCategoryAsync();
        return Ok(categories);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var category = await _categoryService.GetByIdCategoryAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await _categoryService.CreateCategoryAsync(createCategoryDto);
        return Ok("Kategori başarıyla oluşturuldu");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return Ok("Kategori başarıyla silindi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await _categoryService.UpdateCategoryAsync(updateCategoryDto);
        return Ok("Kategori başarıyla güncellendi");
    }
}