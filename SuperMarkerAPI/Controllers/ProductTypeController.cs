using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarkerAPI.Models;
using SuperMarket.Application.Commands.Product;
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
    }
}
