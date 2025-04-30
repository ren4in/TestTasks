using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogStandardizer
{
    public static class LogLevelMapper
    {
        public static string Map(string input)
        {
            return input.ToUpper() switch
            {
                "INFORMATION" => "INFO",
                "INFO" => "INFO",
                "WARNING" => "WARN",
                "WARN" => "WARN",
                "ERROR" => "ERROR",
                "DEBUG" => "DEBUG",
                _ => "UNKNOWN"
            };
        }
    }

}
