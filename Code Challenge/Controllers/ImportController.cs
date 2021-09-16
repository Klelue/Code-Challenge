using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Code_Challenge.Models;
using Code_Challenge.Util;
using Microsoft.EntityFrameworkCore;

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
            DeleteTableRows();
            List<string> values =
                CSVReader.readFile("C:\\Users\\kluenert\\source\\repos\\Code Challenge\\Code Challenge\\sitzplan.csv");
            StringToDatabase stringToDatabase = new StringToDatabase();
            stringToDatabase.IntoDatabase(values, _db);

        }

        [HttpGet]
        public IEnumerable<People> Get()
        {
            return _db.People.ToArray();
        }

        private void DeleteTableRows()
        {
            _db.Database.ExecuteSqlRaw("DELETE FROM People");
            _db.Database.ExecuteSqlRaw("DELETE FROM Room");
            _db.SaveChanges();
        }
    }
}
