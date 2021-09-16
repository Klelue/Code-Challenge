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

        private readonly CodeChallengeDbContext db;

        public ImportController(CodeChallengeDbContext db)
        {
            this.db = db;
        }

        // Post api/<ImportController>
        [HttpPost]
        public ActionResult Post(string filePath)
        {
            filePath = "C:\\Users\\kluenert\\source\\repos\\Code Challenge\\Code Challenge\\sitzplan.csv";
            DeleteTableRows();
            List<string> values = CSVReader.readFile(filePath);
            StringToDatabase stringToDatabase = new StringToDatabase();
            return stringToDatabase.IntoDatabase(values, db);

        }
        
        private void DeleteTableRows()
        {
            db.Database.ExecuteSqlRaw("DELETE FROM People");
            db.Database.ExecuteSqlRaw("DELETE FROM Room");
            db.SaveChanges();
        }
    }
}
