using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test2.CustomDTOs;
using Test2.Services;

namespace Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IFlightService _service;
        public FlightsController(IFlightService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string CityName )
        {
            try {
              var x = _service.GetByCity(CityName);
                return Ok(x);
            }
               catch { 
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(FlightDto flight)
        {
            try { await _service.AddFilght(flight);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();

            }
            
        }
    }
}
