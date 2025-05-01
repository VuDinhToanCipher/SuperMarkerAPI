using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Commands.ProductType;
using SuperMarket.Application.DTOs.ProductTypeDTO;

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
            var resut = await sender.Send(new DeleteProductTypeCommand(IDType));
            if(resut == false)
            {
                return NotFound();
            }
            return Ok(resut);
        }
    }
}
