using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Code_Challenge.Util
{
    public static class CSVReader
    {
        public static List<string> readFile(string Filepath)
        {
            List<string> readedFile = new List<string>();
            try
            {
                using (var reader = new StreamReader(@Filepath))
                {
                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        readedFile.Add(line);
                    }
                }
            }
            catch (IOException e)
            {
                throw ;
            }
            

            return readedFile;
        }
    }
}