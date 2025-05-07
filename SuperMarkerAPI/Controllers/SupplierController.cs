using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Commands.Supplier;
using SuperMarket.Application.DTOs.SupplierDTO;
using SuperMarket.Application.Queries.Supplier;

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
        [HttpGet]
        public async Task<IActionResult> GetSupplierAsync([FromQuery] string Namesupplier = "")
        {
            var result = await sender.Send(new GetSupplierCommand(Namesupplier));   
            return Ok(result);
        }
        [HttpDelete("{IDSupplier}")]
        public async Task<IActionResult> DeleteSupplierAsync(Guid IDSupplier)
        {
            var result = await sender.Send(new  DeleteSupplierCommand(IDSupplier));
            return Ok(result);
        }
    }
}
