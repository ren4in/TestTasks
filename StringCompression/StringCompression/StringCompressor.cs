using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompression
{
    public static class StringCompressor
    {
        public static string Compress(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            if (input.Any(c => !char.IsLetter(c) || !IsLatinLetter(c)))
                throw new ArgumentException("Строка должна содержать только латинские буквы (a-z, A-Z).");

            var sb = new StringBuilder();
            char currentChar = input[0];
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == currentChar)
                    count++;
                else
                {
                    sb.Append(currentChar);
                    if (count > 1)
                        sb.Append(count);
                    currentChar = input[i];
                    count = 1;
                }
            }

            sb.Append(currentChar);
            if (count > 1)
                sb.Append(count);

            return sb.ToString();
        }

        public static string Decompress(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            var sb = new StringBuilder();
            int i = 0;

            while (i < input.Length)
            {
                char letter = input[i++];
                string countStr = "";

                while (i < input.Length && char.IsDigit(input[i]))
                    countStr += input[i++];

                int count = string.IsNullOrEmpty(countStr) ? 1 : int.Parse(countStr);
                sb.Append(new string(letter, count));
            }

            return sb.ToString();
        }

        private static bool IsLatinLetter(char c)
        {
            return (c >= 'a' && c <= 'z');
        }
    }

}
