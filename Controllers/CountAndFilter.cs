using Hotel_Management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Controllers
{
   /* [Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class CountAndFilter : ControllerBase
    {
        private readonly ICountFilterRepository _hotelRepository;

        public CountAndFilter(ICountFilterRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        [HttpGet]
        //[Route("Filter")]
        public IActionResult GetAllHotels(string location = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var hotels = _hotelRepository.GetFilteredHotels(location, minPrice, maxPrice);
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        //[Route("Count-Available-Rooms")]
        public int GetCount(int id)
        {
            var res = _hotelRepository.Results(id);

            return res;
        }
    }
}
