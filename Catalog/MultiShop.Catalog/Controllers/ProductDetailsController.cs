using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailDetailService; 
         
        public ProductDetailDetailsController(IProductDetailService ProductDetailService)
        {
            _productDetailDetailService = ProductDetailService; 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var values = await _productDetailDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetail(string id)
        {
            var values = await _productDetailDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail is create");

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail is delete");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("ProductDetail is update");
        }
    }
}
