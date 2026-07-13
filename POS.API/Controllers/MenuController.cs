using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.DOMAIN.Features.Menu.Queries;
using POS.SHARED;

namespace POS.API.Controllers
{
  
    public class MenuController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var command = new GetAllMenuquery();
                var result = await Mediator.Send(command);

                if (!result.IsSuccess)
                {
                    // Log the error message here: result.ErrorMessages
                    return BadRequest(result); // Use BadRequest for logic errors
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // This catches unhandled exceptions (like SQL connection failures)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An unexpected error occurred.",
                    Details = ex.Message
                });
            }
        }
    }
}
