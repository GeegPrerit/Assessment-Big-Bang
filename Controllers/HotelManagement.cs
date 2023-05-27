using Hotel_Management.Auth;
using Hotel_Management.Model;
using Hotel_Management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hotel_Management.Controllers
{
    //[Authorize(Roles = UserRoles.Owner)]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelManagement : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManagement(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _hotelRepository.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            _hotelRepository.AddHotel(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public ActionResult<ICollection<Hotel>> UpdateHotel(int id, Hotel hotel)
        {
            _hotelRepository.UpdateHotel( id,hotel);
            return Ok(hotel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
            return NoContent();
        }
    }
}
