using HMSDAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMSDAL.Models;
using HMSWeb.DomainViewModel;

namespace HMSWeb.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
   // [Authorize]
    public class RoomController : ControllerBase
    {
        IRoomRepository roomRepository;
        public RoomController(IRoomRepository _roomRepository)
        {
            roomRepository = _roomRepository;
        }

        [HttpGet]
        [Route("GetRoomTypes")]
        public  IActionResult GetRoomTypes()
        {
            try
            {
                var roomTypes = roomRepository.GetRoomTypes();
                if (roomTypes == null)
                {
                    return NotFound();
                }

                return Ok(roomTypes);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetRooms")]
        public IActionResult GetRooms()
        {
            try
            {
                var rooms = roomRepository.GetRooms();
                if (rooms == null)
                {
                    return NotFound();
                }

                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }   

        }
        [HttpPost]
        [Route("AddRoom")]
        public  IActionResult AddRoom([FromBody] RoomModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var roomId =  roomRepository.AddRoom(
                        new Room { 
                                    RoomTypeId=model.RoomTypeId,
                                    RoomNo= model.RoomNo
                        });
                    if (roomId > 0)
                    {
                        return Ok(roomId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
    }
}
