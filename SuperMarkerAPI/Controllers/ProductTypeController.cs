using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Commands.ProductType;
using SuperMarket.Application.DTOs.ProductTypeDTO;
using SuperMarket.Application.Queries.ProductType;

namespace SuperMarkerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddProductTypeAsync([FromBody] AddProductTypeDTO productType)
        {
            var result = await sender.Send(new AddProductTypeCommand(productType));
            return Ok(result);
        }
        [HttpPut("{IDType}")]
        public async Task<IActionResult> UpdateTypeAsync([FromBody] UpdateTypeDTO updateType, Guid IDType)
        {
            var result = await sender.Send(new UpdateProductTypeCommand(IDType,updateType));
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{IDType}")]
        public async Task<IActionResult> DeleteTypeAsync(Guid IDType)
        {
            var result = await sender.Send(new DeleteProductTypeCommand(IDType));
            if(result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("GetProductType")]
        public async Task<IActionResult> GetProductTypeAsync(string? Name)
        {
            var result = await sender.Send(new GetProductTypeCommand(Name));
            return Ok(result);
        }
    }
}
