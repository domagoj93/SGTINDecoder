using SGTINDecoder.BaseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SGTINDecoder.HelperMethods
{
    public static class Validator
    {
        public static bool IsValid_SGTIN_96(string hex_SGTIN_96, bool checkHeader = false, bool checkPartition = false)
        {
            if(!Regex.IsMatch(hex_SGTIN_96, @"\A\b[0-9a-fA-F]+\b\Z") || hex_SGTIN_96.Length != 24)
            {
                return false;
            }

            var ranges = new SGTIN_96_Ranges();
            var binaryString = string.Join(string.Empty,
                    hex_SGTIN_96.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            if (checkHeader)
            {
                var headerBinary = binaryString.Substring(ranges.HeaderStart, ranges.HeaderLength);
                var headerInt = Convert.ToInt32(headerBinary, 2);
                if (headerInt != 48)
                {
                    return false;
                }
            }

            if (checkPartition)
            {
                var partitionBinary = binaryString.Substring(ranges.PartitionStart, ranges.PartitionLength);
                var partitionInt = Convert.ToInt16(partitionBinary, 2);
                if(partitionInt > 6)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
