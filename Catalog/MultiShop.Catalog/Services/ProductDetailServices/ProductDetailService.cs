using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper,IDatabaseSettings _databaseSettings) 
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetail)
        {
            var value=_mapper.Map<ProductDetail>(createProductDetail);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x=>x.ProductDetailId== id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values); 
        }
        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetail)
        {
            var value=_mapper.Map<ProductDetail>(updateProductDetail);
            await _productDetailCollection.FindOneAndReplaceAsync(x=>x.ProductDetailId==updateProductDetail.ProductDetailId,value);
        }
    }
}
