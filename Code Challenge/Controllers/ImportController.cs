using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Code_Challenge.Util;

namespace Code_Challenge.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {

        private readonly CodeChallengeDbContext _db;

        public ImportController(CodeChallengeDbContext db)
        {
            _db = db;
        }

        // Post api/<ImportController>
        [HttpPost]
        public void Post()
        {
            List<string> values =
                CSVReader.readFile("C:\\Users\\kluenert\\source\\repos\\Code Challenge\\Code Challenge\\sitzplan.csv");
            StringToDatabase stringToDatabase = new StringToDatabase();
            stringToDatabase.intoDatabase(values, _db);

        }
    }
}
