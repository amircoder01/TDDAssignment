using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task2
{
    public class StringProcessor
    {
        public string ToLowerCase(string input)
        {
            return input.ToLower();
        }
        public string Sanitize(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            string result = Regex.Replace(input, @"[^0-9a-zA-Z]+", " ");
            return result;
        }
        public bool AreEqual(string input1, string input2)
        {
            if (string.IsNullOrEmpty(input1) && string.IsNullOrEmpty(input2))
            {
                return true;
            }
            if (string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2))
            {
                return false;
            }
            string sanitizedInput1 = Sanitize(input1);
            string sanitizedInput2 = Sanitize(input2);
            return string.Equals(sanitizedInput1, sanitizedInput2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
