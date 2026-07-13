using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.DOMAIN.Features.MenuCategory.Command;
using POS.DOMAIN.Features.MenuCategory.Handler;
using POS.DOMAIN.Features.MenuCategory.Models;
using POS.DOMAIN.Features.MenuCategory.Queries;
using POS.SHARED;

namespace POS.API.Controllers
{

    public class MenuCagController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMenuCag()
        {
            var result = await Mediator.Send(new GetMenuCagAllQuery());


            if (!result.IsSuccess)
            {

                return BadRequest(result.Messages);
            }

            return Ok(result.Data);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateMenuCagCommand menuCag)
        {
            var result = await Mediator.Send(menuCag);

            if (!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteMenuCagCommand { id = id };
            var result = await Mediator.Send(command);

            if (!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( [FromBody] MenuCagRequest menuCag)
        {
            var command = new UpdateMenuCagCommand()
            {

                id = menuCag.id,
                MenuCag_Name = menuCag.MenuCag_Name,
                MenuCag_Des = menuCag.MenuCag_Des
            };

            var result = await Mediator.Send(command);


            if (!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]

        public async Task<IActionResult> Patch([FromRoute] int id , [FromBody] MenuCagRequest menuCag)
        {
            var command = new PatchMenuCagCommand
            {
                id = id,
                MenuCag_Name = menuCag.MenuCag_Name,
                MenuCag_Des = menuCag.MenuCag_Des
            };

            var result = await Mediator.Send(command);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
