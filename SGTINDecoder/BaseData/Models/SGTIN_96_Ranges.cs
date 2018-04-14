using SGTINDecoder.BaseData.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGTINDecoder.BaseData.Models
{
    public class SGTIN_96_Ranges : Ranges
    {
        public override int HeaderLength => 8;
        public override int FilterStart => 8;
        public override int FilterLength => 3;
        public override int PartitionStart => 11;
        public override int PartitionLength => 3;
        public override int CompanyPrefixStart => 14;
        public override int SerialNumberLength => 38;
    }
}
