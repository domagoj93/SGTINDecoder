using SGTINDecoder.BaseData.Models;
using SGTINDecoder.HelperMethods;
using SGTINDecoder.Interfaces;
using SGTINDecoder.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SGTINDecoder
{
    public static class Decoder
    {
        public static SGTIN_96 Decode_SGTIN_96(string EPC_tag)
        {
            // result of SGTIN-96 object
            var result = new SGTIN_96();
            result.HexValue = EPC_tag;

            //check if EPC_tag is valid SGTIN-96 tag
            if (!Validator.IsValid_SGTIN_96(EPC_tag, true, true))
            {
                result.IsProperlyEncoded = false;
                result.ItemReference = 0;
                return result;
            }
            result.IsProperlyEncoded = true;
            
            // object for SGTIN-96 ranges 
            var ranges = new SGTIN_96_Ranges();

            //converting SGTIN-96 to binary string
            string binaryString = "";

            //binaryString = Convert.ToString(Convert.ToInt32(EPC_tag, 16), 2);
            binaryString = string.Join(
            string.Empty,
            EPC_tag.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

            //separating and decoding binary string
            var headerBinary = binaryString.Substring(ranges.HeaderStart, ranges.HeaderLength);
            result.Header = Convert.ToInt32(headerBinary, 2);

            var filterBinary = binaryString.Substring(ranges.FilterStart, ranges.FilterLength);
            result.Filter = Convert.ToInt16(filterBinary, 2);

            var partitionBinary = binaryString.Substring(ranges.PartitionStart, ranges.PartitionLength);
            result.Partition = Convert.ToInt16(partitionBinary, 2);

            var partitionResult = PartitionResolveHelper.GetCompanyPrefixAndItemReference(result.Partition);

            var companyPrefixBinary = binaryString.Substring(ranges.CompanyPrefixStart, partitionResult.CompanyPrefixBitsCount);
            result.CompanyPrefix = Convert.ToInt64(companyPrefixBinary, 2);

            var itemReferenceBinary = binaryString.Substring(ranges.CompanyPrefixStart + partitionResult.CompanyPrefixBitsCount, partitionResult.ItemReferenceBitsCount);
            result.ItemReference = Convert.ToInt32(itemReferenceBinary, 2);

            result.SerialNumber = string.Concat(binaryString.TakeLast(ranges.SerialNumberLength));

            return result;
        }
    }
}
