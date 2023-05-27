using Hotel_Management.Auth;
using Hotel_Management.Model;
using Hotel_Management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hotel_Management.Controllers
{
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Owner)]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _RoomRepository;

        public RoomController(IRoomRepository RoomsRepository)
        {
            _RoomRepository = RoomsRepository;
        }
        [HttpGet]
        public ActionResult<ICollection<Room>> GetAllHotels()
        {
            var hotels = _RoomRepository.GetAllRoom();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult<ICollection<Room>> GetHotelById(int id)
        {
            var rooms = _RoomRepository.GetRoomById(id);
            return Ok(rooms);
        }

        [HttpPost]
        public ActionResult<ICollection<Room>> CreateHotel(Room rooms)
        {
            _RoomRepository.AddRoom(rooms);
            return Ok(rooms);
        }

        [HttpPut("{id}")]
        public ActionResult<ICollection<RoomController>> UpdateHotel(int id, Room rooms)
        {
            _RoomRepository.UpdateRoom(rooms, id);
            return Ok(rooms);
        }

        [HttpDelete("{id}")]
            public ActionResult<ICollection<RoomController>> DeleteHotel(int id)
            {
                _RoomRepository.DeleteRoom(id);
                return Ok(id);
            }
        }
    }

