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
        public async Task<List<Hotel>> Get()
        {
            //throw new InvalidOperationException("Something bad happened here!");
            return await _hotelService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hotel hotel)
        {
            await _hotelService.CreateHotel(hotel);
            return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
        }
    }
}
