using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using static Code_Challenge.Util.JsonErrorCode;

namespace Code_Challenge.Util
{
    public static class CSVReader
    {
        public static ActionResult<List<string>> ReadFile(string Filepath)
        {
            List<string> stringListValues = new List<string>();
            try
            {
                using (var reader = new StreamReader(@Filepath))
                {
                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        stringListValues.Add(line);
                    }
                }
            }
            catch (IOException e)
            {
                return new BadRequestObjectResult(ErrorCodeAsJson(400, "This was no valid csv data"));
            }
            

            return stringListValues;
        }
    }
}