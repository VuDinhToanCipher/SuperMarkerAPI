using AutoMapper;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Application.DTOs.ProductTypeDTO;

namespace SuperMarket.Application.MappingProfiles
{
    public class MappingProfile  : Profile
    {
        public MappingProfile() 
        {
            //Mapping ProductEntity
            CreateMap<ProductEntity, GetProductsDTO>();
            CreateMap<ProductEntity, PostProductsDTO>();
            CreateMap<ProductEntity, PutProductsDTO>()
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductTypeID));
            //Mapping ProductDTO
            CreateMap<GetProductsDTO,ProductEntity >();
            CreateMap<PostProductsDTO, ProductEntity>();
            CreateMap<PutProductsDTO, ProductEntity>()
                .ForMember(dest => dest.ProductTypeID, opt => opt.MapFrom(src => src.ProductType)) // Map ProductType to ProductTypeID
                .ForMember(dest => dest.productType, opt => opt.Ignore()); // Ignore productType navigation property
            //Mapping ProductTypeEntity
            CreateMap<ProductTypeEntity, AddProductTypeDTO>();
            CreateMap<ProductTypeEntity,GetProductTypeDTO>();
            CreateMap<ProductTypeEntity,UpdateTypeDTO>();
            //Mapping ProductTypeDTO
            CreateMap<AddProductTypeDTO, ProductTypeEntity>();
            CreateMap<GetProductTypeDTO,ProductTypeEntity>();
            CreateMap<UpdateTypeDTO,ProductTypeEntity>();
        }
    }
}
