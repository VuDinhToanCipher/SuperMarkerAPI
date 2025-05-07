using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.SupplierDTO;
using SuperMarket.Application.Interfaces;
using SuperMarket.Core.Entities;

namespace SuperMarket.Application.Commands.Supplier
{
    public record UpdateSupplierCommand(UpdateSupplierDTO UpdateSupplier,Guid IDSupplier) : IRequest<UpdateSupplierDTO>;
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, UpdateSupplierDTO>
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public UpdateSupplierCommandHandler(ISupplierService _supplierService, IMapper _mapper)
        {
            this._supplierService = _supplierService;
            this._mapper = _mapper;
        }
        public async Task<UpdateSupplierDTO> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<SupplierEntity>(request.UpdateSupplier);
            var result = await _supplierService.UpdateSupplierAsync(request.IDSupplier, supplier);
            return _mapper.Map<UpdateSupplierDTO>(result);  
        }
    }


}
