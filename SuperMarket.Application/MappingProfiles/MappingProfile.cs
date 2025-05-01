using AutoMapper;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;

namespace SuperMarket.Application.MappingProfiles
{
    public class MappingProfile  : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ProductEntity, GetProductsDTO>();
            CreateMap<ProductEntity, PostProductsDTO>();
            CreateMap<ProductEntity, PutProductsDTO>()
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductTypeID));
            CreateMap<GetProductsDTO,ProductEntity >();
            CreateMap<PostProductsDTO, ProductEntity>();
            CreateMap<PutProductsDTO, ProductEntity>()
                .ForMember(dest => dest.ProductTypeID, opt => opt.MapFrom(src => src.ProductType)) // Map ProductType to ProductTypeID
                .ForMember(dest => dest.productType, opt => opt.Ignore()); // Ignore productType navigation property

        }
    }
}
