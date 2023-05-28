using Hotel_Management.Auth;
using Hotel_Management.Exceptions;
using Hotel_Management.Model;
using Hotel_Management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    [Authorize(Roles = UserRoles.Owner)]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelManagementController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManagementController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            try
            {
                var hotels = _hotelRepository.GetAllHotels();
                return Ok(hotels);
            }
            catch (AuthorizationException)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "You are not authorized to access this resource.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the list of hotels.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var hotel = _hotelRepository.GetHotelById(id);
                if (hotel == null)
                    return NotFound($"Hotel with ID {id} not found.");

                return Ok(hotel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the hotel details.");
            }
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            try
            {
                _hotelRepository.AddHotel(hotel);
                return CreatedAtAction(nameof(GetHotelById), new { id = hotel.Id }, hotel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the hotel.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            try
            {
                _hotelRepository.UpdateHotel(id, hotel);
                return Ok(hotel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the hotel with ID {id}.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                _hotelRepository.DeleteHotel(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the hotel with ID {id}.");
            }
        }
    }
}
