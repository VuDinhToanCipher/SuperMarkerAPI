using AutoMapper;
using AutoMapper.Configuration.Conventions;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Application.DTOs.Product_Supplier_DTO;
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
            //Mapping Product_Supplier
            CreateMap<Supplier_Product_Entity, Add_Product_Supplier_DTO>();
            CreateMap<Add_Product_Supplier_DTO, Supplier_Product_Entity>();
            CreateMap<Supplier_Product_Entity, Get_Supplier_Product_DTO>()
                .ForMember(dest => dest.ProductName, otp => otp.MapFrom(src => src.ProductEntity.NameProduct))
                .ForMember(dest => dest.SupplierName, otp => otp.MapFrom(src => src.SupplierEntity.SupplierName));
            CreateMap<Get_Supplier_Product_DTO, Supplier_Product_Entity>();
        }
    }
}
