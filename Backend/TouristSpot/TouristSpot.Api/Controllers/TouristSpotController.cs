using Application.UseCases.TouristSpot.Get;
using Microsoft.AspNetCore.Mvc;
using TouristSpot.Application.UseCases.TouristSpotServices.Get;
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

        [HttpGet("{orderBy?}")]
        [ProducesResponseType(typeof(OutputRegisterTouristSpot), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
        [FromServices] IGetTouristSpots useCase,
        string orderBy = "ASC")
        {
            var input = new InputGetTouristSpot(string.Empty, orderBy);
            var response = await useCase.Execute(input);
            if (response.TouristsSpots.Any())
                return Ok(response);

            return NoContent();
        }
    }
}
