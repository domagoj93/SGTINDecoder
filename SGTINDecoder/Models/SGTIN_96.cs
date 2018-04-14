using SGTINDecoder.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGTINDecoder.Models
{
    public class SGTIN_96 : ISGTIN
    {
        public long Header { get; set; }
        public int Filter { get; set; }
        public int Partition { get; set; }
        public long CompanyPrefix { get; set; }
        public long ItemReference { get; set; }
        public string SerialNumber { get; set; }
        public bool IsProperlyEncoded { get; set; }
        public string HexValue { get; set; }
        public string SGTIN_Type => "SGTIN-96";
    }
}
