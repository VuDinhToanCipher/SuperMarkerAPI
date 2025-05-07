using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.Product_Supplier_DTO;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Queries.Supplier_Product
{
    public record GetSupplier_Product_Query(Guid? IdProduct,Guid? IdSupplier):IRequest<IEnumerable<Get_Supplier_Product_DTO>>;
    public class GetSupplier_Product_QueryHandler : IRequestHandler<GetSupplier_Product_Query, IEnumerable<Get_Supplier_Product_DTO>>
    {
        private readonly IMapper _mapper;
        private readonly IProduct_Supplier_Respository _service;
        public GetSupplier_Product_QueryHandler(IMapper _mapper, IProduct_Supplier_Respository _service)
        {
            this._mapper = _mapper;
            this._service = _service;
        }
        public async Task<IEnumerable<Get_Supplier_Product_DTO>> Handle(GetSupplier_Product_Query request, CancellationToken cancellationToken)
        {
            var result  = await _service.GetSupplier_Product_Async(request.IdSupplier,request.IdProduct);
            return  _mapper.Map<IEnumerable<Get_Supplier_Product_DTO>>(result);
        }
    }
}
