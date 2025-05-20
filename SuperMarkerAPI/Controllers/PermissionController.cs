using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Application.Commands.Permission;
using SuperMarket.Application.DTOs.Permission;
using SuperMarket.Application.DTOs.PermissionDTO;

namespace SuperMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddPermissionAsync(AddPermisstionDTO addPermisstionDTO)
        {
            var result = await sender.Send(new AddPermissionCommand(addPermisstionDTO));
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePermissionAsync([FromQuery] Guid PermissionID, [FromBody] UpdatePermissionDTO updatePermissionDTO)
        {
            var result = await sender.Send(new UpdatePermissionCommand(PermissionID, updatePermissionDTO));
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePermissionAsync([FromQuery] Guid PermissionID)
        {
            var result = await sender.Send(new DeletePermissionCommand(PermissionID));
            return Ok(result);
        }
    }
}
