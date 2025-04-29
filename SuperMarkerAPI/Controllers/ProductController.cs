using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarkerAPI.Models;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Application.Commands;
using SuperMarket.Application.Commands.Product;

namespace SuperMarkerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ProductEntity> GetProducts()
        {
            return new List<ProductEntity>();
        }
        [HttpPost("")]
        public async Task<IActionResult> AddProductAsync([FromBody] PostProductsDTO productsDTO)
        {
            var result = await sender.Send(new AddProductCommand(productsDTO));
            return Ok(result);
        }
    }
}
