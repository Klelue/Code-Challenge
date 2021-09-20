using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using Code_Challenge.Models;
using Code_Challenge.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static Code_Challenge.Util.JsonErrorCode;

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
        /*[HttpPost]
        public ActionResult PostFilePath(string filePath)
        {
            filePath = "C:\\Users\\kluenert\\source\\repos\\Code Challenge\\Code Challenge\\sitzplan.csv";
            return SaveStringsIntoDatabase(filePath);
        }*/

        [HttpPost]
        public ActionResult PostFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     file.CopyTo(stream);
                }
                return SaveStringsIntoDatabase(filePath);
            }

            return BadRequest(ErrorCodeAsJson(400, "Empty File"));
        }

        private ActionResult SaveStringsIntoDatabase(string filePath)
        {
            ActionResult<List<string>> values = CSVReader.ReadFile(filePath);
            if (values.Value.Count > 0)
            {
                StringToDatabase stringToDatabase = new StringToDatabase(db);
                return stringToDatabase.SaveStringsIntoDatabase(values.Value);
            }

            return values.Result;
        }
        
    }
}
