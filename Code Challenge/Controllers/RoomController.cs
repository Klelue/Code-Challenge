using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Code_Challenge.Models;
using Code_Challenge.Util;
using static Code_Challenge.Util.JsonErrorCode;

namespace Code_Challenge.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly CodeChallengeDbContext db;

        public RoomController(CodeChallengeDbContext db)
        {
            this.db = db;
        }

        // GET api/<RoomController>
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return RoomsWithPeople(db.Room);
        }

        // GEt api/<RoomController>/5
        [HttpGet("{roomNumber}")]
        public ActionResult<IEnumerable<Room>> Get(string roomNumber)
        {
            if (roomNumber.Length == 4)
            {
                
                IEnumerable<Room> rooms = db.Room.Where(room=> room.RoomNumber.Equals(roomNumber));
                if(rooms.Any()){

                    return Ok(RoomsWithPeople(rooms));
                }

                return NotFound(ErrorCodeAsJson(404, "Room number was not 4 digits"));
            }

            return BadRequest(ErrorCodeAsJson(400, "Room number was not 4 digits"));
        }
        
        private IEnumerable<Room> RoomsWithPeople(IEnumerable<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                List<People> peoples = db.People.Where(people => people.RoomNumber.Equals(room.RoomNumber)).ToList();
                room.Residents = peoples;
            }
            return rooms;
        }

    }
}
