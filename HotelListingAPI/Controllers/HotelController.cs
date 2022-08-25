using HotelListingAPI.Models;
using HotelListingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelListingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;
        private readonly ILogger<HotelController> _logger;

        public HotelController(HotelService hotelService, ILogger<HotelController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
            _logger.LogInformation("HotelController initialized...");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<List<Hotel>> Get()
        {
            return await _hotelService.GetAll();
        }

        // What to return??? Error (IActionResult) and Model (Hotel) have to work!?!?
        [HttpGet("{userId}")]
        public async Task<object> Get(string userId)
        {
            try
            {
                var hotel = await _hotelService.GetById(userId);
                if (hotel == null)
                {
                    return StatusCode(404, ErrorModels.NotFoundError(userId).ToString());
                }
                return hotel;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, ErrorModels.InternalServerError().ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hotel hotel)
        {
            await _hotelService.CreateHotel(hotel);
            return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
        }




        // standard error message with stack trace --> maybe bad in production!?
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [Route("exc")]
        public string ExceptionExample()
        {
            throw new InvalidOperationException($"Some custom error inside '{nameof(ExceptionExample)}'");
        }

        [HttpGet]
        [Route("exc2")]
        public ObjectResult ExceptionExample2()
        {
            return StatusCode(304, "blub");
        }

        [HttpGet]
        [Route("exc3")]
        public ObjectResult ExceptionExample3()
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Something went wrong in {nameof(ExceptionExample3)}");
        }

        [HttpGet]
        [Route("exc4")]
        public ObjectResult ExceptionExample4()
        {
            return Problem($"Something went wrong in the {nameof(ExceptionExample4)}", statusCode: 500);
        }
    }
}
