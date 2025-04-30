using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogStandardizer
{
    public class StandardLogEntry
    {
        public string Date { get; set; } // DD-MM-YYYY
        public string Time { get; set; }
        public string LogLevel { get; set; } // INFO, WARN, etc.
        public string Method { get; set; } // может быть DEFAULT
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Date}\t{Time}\t{LogLevel}\t{Method}\t{Message}";
        }
    }

}
