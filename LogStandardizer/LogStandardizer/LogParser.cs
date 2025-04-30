using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogStandardizer
{
    using System;
    using System.Text.RegularExpressions;

    public static class LogParser
    {
        public static bool TryParse(string line, out StandardLogEntry entry)
        {
            entry = null;

            // Формат 1: "10.03.2025 15:14:49.523 INFORMATION  Версия программы: '3.4.0.48729'"
            var regex1 = new Regex(@"^(\d{2}\.\d{2}\.\d{4}) (\d{2}:\d{2}:\d{2}\.\d+)\s+(\w+)\s+(.*)$");

            // Формат 2: "2025-03-10 15:14:51.5882| INFO|11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO...'"
            var regex2 = new Regex(@"^(\d{4}-\d{2}-\d{2}) (\d{2}:\d{2}:\d{2}\.\d+)\|\s*(\w+)\|.*?\|(.*?)\|\s+(.*)$");

            Match match;

            if ((match = regex1.Match(line)).Success)
            {
                // Формат 1
                string date = ConvertDate(match.Groups[1].Value); // DD-MM-YYYY
                string time = match.Groups[2].Value;
                string level = LogLevelMapper.Map(match.Groups[3].Value);
                string message = match.Groups[4].Value;

                entry = new StandardLogEntry
                {
                    Date = date,
                    Time = time,
                    LogLevel = level,
                    Method = "DEFAULT",
                    Message = message
                };
                return true;
            }
            else if ((match = regex2.Match(line)).Success)
            {
                // Формат 2
                string date = ConvertDate(match.Groups[1].Value); // YYYY-MM-DD -> DD-MM-YYYY
                string time = match.Groups[2].Value;
                string level = LogLevelMapper.Map(match.Groups[3].Value);
                string method = match.Groups[4].Value.Trim();
                string message = match.Groups[5].Value;

                entry = new StandardLogEntry
                {
                    Date = date,
                    Time = time,
                    LogLevel = level,
                    Method = method,
                    Message = message
                };
                return true;
            }

            return false;
        }

        private static string ConvertDate(string input)
        {
            // input: "10.03.2025" или "2025-03-10"
            if (input.Contains('.')) // DD.MM.YYYY
            {
                var parts = input.Split('.');
                return $"{parts[2]}-{parts[1]}-{parts[0]}";
            }
            else if (input.Contains('-')) // YYYY-MM-DD
            {
                var parts = input.Split('-');
                return $"{parts[2]}-{parts[1]}-{parts[0]}";
            }

            return input;
        }
    }

}
