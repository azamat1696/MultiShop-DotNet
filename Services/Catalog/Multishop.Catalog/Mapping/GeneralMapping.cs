using AutoMapper;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Dtos.ProductImageDtos;
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Mapping;

public class GeneralMapping : Profile
{
  public GeneralMapping()
  {
      CreateMap<Category, CreateCategoryDto>().ReverseMap();
      CreateMap<Category, UpdateCategoryDto>().ReverseMap();
      CreateMap<Category, ResultCategoryDto>().ReverseMap();
      CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
      
      CreateMap<Product, CreateProductDto>().ReverseMap();
      CreateMap<Product, UpdateProductDto>().ReverseMap();
      CreateMap<Product, ResultProductDto>().ReverseMap();
      CreateMap<Product, GetByIdProductDto>().ReverseMap();
      
      CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
      CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
      CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
      CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
      
      CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
      CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
      CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
      CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
  }
}