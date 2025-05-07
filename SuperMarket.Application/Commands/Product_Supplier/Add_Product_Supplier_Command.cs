using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.Product_Supplier_DTO;
using SuperMarket.Application.Interfaces;

namespace SuperMarket.Application.Commands.Product_Supplier
{
    public record Add_Product_Supplier_Command(Guid ProductID, Guid SupplierID):IRequest<Add_Product_Supplier_DTO>;
    public class Add_Product_Supplier_CommandHandler : IRequestHandler<Add_Product_Supplier_Command, Add_Product_Supplier_DTO>
    {
        private readonly IMapper _mapper;
        private readonly IProduct_Supplier_Service _service;
        public Add_Product_Supplier_CommandHandler(IMapper _mapper, IProduct_Supplier_Service _service)
        {
            this._mapper = _mapper;
            this._service = _service;
        }
        public async Task<Add_Product_Supplier_DTO> Handle(Add_Product_Supplier_Command request, CancellationToken cancellationToken)
        {
            var result = await _service.AddSupplier_Product_Async(request.ProductID, request.SupplierID);
            return _mapper.Map<Add_Product_Supplier_DTO>(result);
        }
    }
}
