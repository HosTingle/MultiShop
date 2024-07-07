using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService ProductService) 
        {
            _productImageService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var values = await _productImageService.GetAllProductImageAsync(); 
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(string id)
        {
            var values = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductImageDto createProductDto)
        {
            await _productImageService.CreateProductImageAsync(createProductDto);
            return Ok("ProductImage is create");

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("ProductImage is delete");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductImageDto updateProductDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductDto);
            return Ok("ProductImage is update");
        }
    }
}
