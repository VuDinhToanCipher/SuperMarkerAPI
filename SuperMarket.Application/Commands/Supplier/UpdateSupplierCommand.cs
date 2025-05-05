using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.SupplierDTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.Supplier
{
    public record UpdateSupplierCommand(UpdateSupplierDTO UpdateSupplier,Guid IDSupplier) : IRequest<UpdateSupplierDTO>;
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, UpdateSupplierDTO>
    {
        private readonly ISupplierRespository _supplierRes;
        private readonly IMapper _mapper;
        public UpdateSupplierCommandHandler(ISupplierRespository _supplierRes, IMapper _mapper)
        {
            this._supplierRes = _supplierRes;
            this._mapper = _mapper;
        }
        public async Task<UpdateSupplierDTO> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<SupplierEntity>(request.UpdateSupplier);
            var result = await _supplierRes.UpdateSupplierAsync(request.IDSupplier, supplier);
            return _mapper.Map<UpdateSupplierDTO>(result);  
        }
    }


}
