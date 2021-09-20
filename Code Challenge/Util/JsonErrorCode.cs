using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_Challenge.Util
{
    public class JsonErrorCode
    {
        public static string ErrorCodeAsJson(int code, string message)
        {
            return "{  \"code\": " + code + " , \"message\": \" " +  message + "\" }";
        }
    }
}
