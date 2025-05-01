using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperMarkerAPI.Models.DTOs.ProductsDTO;
using SuperMarket.Application.Commands.Product;

namespace SuperMarkerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) : ControllerBase
    {
        [HttpGet("Search")]
        public async Task<IActionResult> GetProductByNameAndTypeAsync([FromQuery] string productName = "" , [FromQuery] string productType = "") 
        {
            var result = await sender.Send(new GetProductByNameAndTypeCommand(productName, productType));
            return Ok(result);
        }
        [HttpGet("SearchPrice")]
        public async Task<IActionResult> GetProductByPriceAsync([FromQuery] decimal? maxPrice , [FromQuery] decimal? minPrice)
        {
            var result = await sender.Send(new GetProductByPriceCommand(maxPrice, minPrice));
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddProductAsync([FromBody] PostProductsDTO productsDTO)
        {
            var result = await sender.Send(new AddProductCommand(productsDTO));
            return Ok(result);
        }
        [HttpPut("{IDProduct}")]
        public async Task<IActionResult> UpdateProductAsync(Guid IDProduct,[FromBody] PutProductsDTO putProductsDTO)
        {
            var result = await sender.Send(new UpdateProductCommand(IDProduct, putProductsDTO));
            return Ok(result);
        }
        [HttpDelete("{IDProduct}")]
        public async Task<IActionResult> DeleteProductAsync(Guid IDProduct)
        {
            var result = await sender.Send(new  DeleteProductCommand(IDProduct));
            return Ok(result);
        }
    }
}
