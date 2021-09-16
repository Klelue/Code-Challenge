using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code_Challenge.Models;
using Code_Challenge.Util;

namespace Code_Challenge.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly CodeChallengeDbContext _db;

        public RoomController(CodeChallengeDbContext db)
        {
            _db = db;
        }

        // GET api/<RoomController>
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return RoomsWithPeople(_db.Room);
        }

        // GEt api/<RoomController>/5
        [HttpGet("{roomNumber}")]
        public ActionResult<IEnumerable<Room>> Get(string roomNumber)
        {
            if (roomNumber.Length == 4)
            {
                
                IEnumerable<Room> rooms = _db.Room.Where(x=> x.RoomNumber.Equals(roomNumber));
                if(rooms.Any()){

                    return Ok(RoomsWithPeople(rooms));
                }

                return NotFound("No room with this number found");
            }

            return BadRequest("Room number was not 4 digits");
        }

        private IEnumerable<Room> RoomsWithPeople(IEnumerable<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                List<People> peoples = _db.People.Where(people => people.RoomNumber.Equals(room.RoomNumber)).ToList();
                room.Residents = peoples;
            }
            return rooms;
        }

    }
}
