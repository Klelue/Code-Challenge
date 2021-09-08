using Microsoft.AspNetCore.Http;
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
    public class ImportController : ControllerBase
    {
        // Post api/import/
        public void Post()
        {
            List<string> values =
                CSVReader.readFile("C:\\Users\\kluenert\\source\repos\\Code Challenge\\Code Challenge\\sitzplan.csv");
            StringToDatabase stringToDatabase = new StringToDatabase();
            List<Room> rooms = stringToDatabase.intoDatabase(values);
        }
    }
}
