using AutoMapper;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Application.DTOs.SupplierDTO;
using SuperMarket.Core.Entities;

namespace SuperMarket.Application.MappingProfiles
{
    public class MappingProfile  : Profile
    {
        public MappingProfile() 
        {
            //Mapping ProductEntity and DTO
            CreateMap<ProductEntity, GetProductsDTO>();
            CreateMap<ProductEntity, PostProductsDTO>();
            CreateMap<ProductEntity, PutProductsDTO>()
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductTypeID));
            CreateMap<GetProductsDTO,ProductEntity >();
            CreateMap<PostProductsDTO, ProductEntity>();
            CreateMap<PutProductsDTO, ProductEntity>()
                .ForMember(dest => dest.ProductTypeID, opt => opt.MapFrom(src => src.ProductType)) // Map ProductType to ProductTypeID
                .ForMember(dest => dest.productType, opt => opt.Ignore()); // Ignore productType navigation property
            //Mapping ProductTypeEntity and DTO
            CreateMap<ProductTypeEntity, AddProductTypeDTO>();
            CreateMap<ProductTypeEntity,GetProductTypeDTO>();
            CreateMap<ProductTypeEntity,UpdateTypeDTO>();
            CreateMap<AddProductTypeDTO, ProductTypeEntity>();
            CreateMap<GetProductTypeDTO,ProductTypeEntity>();
            CreateMap<UpdateTypeDTO,ProductTypeEntity>();
            //Mapping Supplier
            CreateMap<SupplierEntity, AddSupplierDTO>();
            CreateMap<AddSupplierDTO,SupplierEntity>();
            CreateMap<SupplierEntity, UpdateSupplierDTO>();
            CreateMap<UpdateSupplierDTO, SupplierEntity>();
            CreateMap<SupplierEntity, GetSupplierDTO>();
            CreateMap<GetSupplierDTO, SupplierEntity>();
        }
    }
}
