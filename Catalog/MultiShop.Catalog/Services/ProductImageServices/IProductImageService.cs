using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();

        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto); 

        Task DeleteProductImageAsync(string id);

        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto); 

        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);  
    }
}
