using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SGTINDecoder.HelperMethods
{
    public static class Validator
    {
        public static bool IsValid_SGTIN_96(string hex_SGTIN_96)
        {
            if(!Regex.IsMatch(hex_SGTIN_96, @"\A\b[0-9a-fA-F]+\b\Z") || hex_SGTIN_96.Length != 24)
            {
                return false;
            }
            return true;
        }
    }
}
