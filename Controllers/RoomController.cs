using Hotel_Management.Auth;
using Hotel_Management.Model;
using Hotel_Management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Hotel_Management.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            try
            {
                var rooms = _roomRepository.GetAllRoom();
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the rooms.");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Owner)]
        public IActionResult GetRoomById(int id)
        {
            try
            {
                var room = _roomRepository.GetRoomById(id);
                if (room == null)
                    return NotFound("Room not found.");

                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the room.");
            }
        }

        [HttpPost]
        public IActionResult CreateRoom(Room room)
        {
            try
            {
                _roomRepository.AddRoom(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the room.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Owner)]
        public IActionResult UpdateRoom(int id, Room room)
        {
            try
            {
                _roomRepository.UpdateRoom(room, id);
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the room.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                _roomRepository.DeleteRoom(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the room.");
            }
        }
    }
}
