using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.SupplierDTO;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Commands.Supplier
{
    public record AddSupplierCommand(AddSupplierDTO SupplierDTO) : IRequest<AddSupplierDTO>;
    public class AddSupplierCommandHandler : IRequestHandler<AddSupplierCommand, AddSupplierDTO>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _Mapper;
        public AddSupplierCommandHandler(ISupplierService _supplierService, IMapper _Mapper)
        {
            this._Mapper = _Mapper; 
            this._supplierService = _supplierService;
        }
        public async Task<AddSupplierDTO> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            var SpDTO = _Mapper.Map<SupplierEntity>(request.SupplierDTO);
            var result = await _supplierService.AddSupplierAsync(SpDTO);
            return _Mapper.Map<AddSupplierDTO>(result);
        }
    }


}
