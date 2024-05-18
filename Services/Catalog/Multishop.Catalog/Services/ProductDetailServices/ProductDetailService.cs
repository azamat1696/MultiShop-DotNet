using System.Diagnostics;
using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName); 
        _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName ?? "ProductDetails");
        _mapper = mapper;
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var values = await _productDetailCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(values);
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var values = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _productDetailCollection.InsertOneAsync(values);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var value = await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(value);
    }
}