using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService 
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync(); 

        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetail);

        Task DeleteProductDetailAsync(string id);  

        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetail);

        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id); 
    }
}
