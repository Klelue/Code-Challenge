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
            return _db.Room.ToArray();
        }

        // GEt api/<RoomController>/5
        [HttpGet("{id}")]
        public string Get(string roomNuber)
        {
            return _db.Room.Where(x=> x.RoomNumber.Equals(roomNuber)).ToString();
        }
    }
}
