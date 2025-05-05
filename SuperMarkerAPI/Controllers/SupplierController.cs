using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Commands.Supplier;
using SuperMarket.Application.DTOs.SupplierDTO;

namespace SuperMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddSupplierAsync([FromBody] AddSupplierDTO supplierDTO)
        {
            var result = await sender.Send(new AddSupplierCommand(supplierDTO));
            return Ok(result);
        }
        [HttpPut("{IDSupplier}")]
        public async Task<IActionResult> UpdateSupplierAsync(Guid IDSupplier, [FromBody] UpdateSupplierDTO supplierDTO)
        {
            var result = await sender.Send(new UpdateSupplierCommand(supplierDTO,IDSupplier));
            return Ok(result);
        }

    }
}
