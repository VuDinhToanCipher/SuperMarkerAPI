using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Commands.Product_Supplier;
using SuperMarket.Application.Queries.Supplier_Product;

namespace SuperMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_SupplierController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddProduct_SupplierAsync([FromQuery] Guid SupplierId, [FromQuery] Guid ProductID)
        {
            var result = await sender.Send(new Add_Product_Supplier_Command(ProductID,SupplierId));
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier_ProductAsync([FromQuery] Guid SupplierId, [FromQuery] Guid ProductID)
        {
            var result = await sender.Send(new Delete_Product_Supplier_Command(ProductID, SupplierId));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetSupplier_ProductAsync( [FromQuery] Guid? SupplierId, [FromQuery] Guid? ProductID)
        {
            var result = await sender.Send(new GetSupplier_Product_Query(ProductID,SupplierId));
            return Ok(result);
        }
    }
}
