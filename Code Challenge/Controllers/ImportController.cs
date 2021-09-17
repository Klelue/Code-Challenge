using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
            ActionResult<List<string>> values = CSVReader.readFile(filePath);
            if (values.Value.Count > 0)
            {
                StringToDatabase stringToDatabase = new StringToDatabase(db);
                return stringToDatabase.IntoDatabase(values.Value);
            }

            return values.Result;


        }
        
    }
}
