using Microsoft.AspNetCore.Mvc;
using TouristSpot.Application.UseCases.TouristSpotServices.Register;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TouristSpotController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(OutputRegisterTouristSpot), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromServices]IRegisterTouristSpot useCase,
            [FromBody]InputRegisterTouristSpot request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
