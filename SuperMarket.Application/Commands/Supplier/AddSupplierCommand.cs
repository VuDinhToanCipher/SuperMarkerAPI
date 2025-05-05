using AutoMapper;
using MediatR;
using SuperMarket.Application.DTOs.SupplierDTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;

namespace SuperMarket.Application.Commands.Supplier
{
    public record AddSupplierCommand(AddSupplierDTO SupplierDTO) : IRequest<AddSupplierDTO>;
    public class AddSupplierCommandHandler : IRequestHandler<AddSupplierCommand, AddSupplierDTO>
    {
        ISupplierRespository _Respository;
        IMapper _Mapper;
        public AddSupplierCommandHandler(ISupplierRespository _Respository, IMapper _Mapper)
        {
            this._Mapper = _Mapper;
            this._Respository = _Respository;
        }
        public async Task<AddSupplierDTO> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            var SpDTO = _Mapper.Map<SupplierEntity>(request.SupplierDTO);
            var result = await _Respository.AddSupplierAsync(SpDTO);
            return _Mapper.Map<AddSupplierDTO>(result);
        }
    }


}
