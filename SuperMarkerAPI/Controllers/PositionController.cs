using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Commands.Position;
using SuperMarket.Application.DTOs.PositionDTO;
using SuperMarket.Application.Queries.Position;

namespace SuperMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddPositionAsync(AddPositionDTO positionDTO)
        {
            var result = await sender.Send(new AddPositionCommand(positionDTO));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePotitionAsync([FromQuery]Guid PositionID, [FromBody]UpdatePositionDTO positionDTO)
        {
            var result = await sender.Send(new UpdatePositionCommand(PositionID, positionDTO));
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> UpdatePotitionAsync([FromQuery] Guid PositionID)
        {
            var result = await sender.Send(new DeletePositionCommand(PositionID));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPositionAsyc()
        {
            var result = await sender.Send(new GetAllPositionQuery());
            return Ok(result);
        }
    }
}
