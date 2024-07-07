using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task DeleteProductAsync(string id);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ResultProductDto> GetByIdProductAsync(string id);
    }
}
