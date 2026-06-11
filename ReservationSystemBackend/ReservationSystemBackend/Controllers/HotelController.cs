using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ReservationSystemBackend.Data.DTOs;
using ReservationSystemBackend.Interfaces;
using ReservationSystemBackend.Services;

namespace ReservationSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelController(HotelService hotelService) {

            _hotelService = hotelService;
        }

        [HttpPost("CreateHotel")]
        public async Task<IActionResult> CreateHotel(CreateHotelDTO createHotelDTO) {

            if (await _hotelService.CreateHotel(createHotelDTO))
                return Created();
            return BadRequest("Failed to Create Hotel");
        }


        [HttpGet("GetAllHotels")]
        public async Task<IActionResult> GetHotels() {

            var hotels = await _hotelService.GetAllHotels();
            if(hotels!=null)
                return Ok(hotels);
            return BadRequest("Can't get hotels");
        }

       
    }
}
