using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code_Challenge.Models;

namespace Code_Challenge.Controllers
{
    [Route("api/room/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {

        // GET api/room/
        public IEnumerable<Room> Get()
        {
            return null;
        }

        // GEt api/room/5
        public string Get(string roomNuber)
        {
            return null;
        }
    }
}
