using System;
using System.Collections.Generic;
using System.Text;

namespace SGTINDecoder.BaseData.Abstractions
{
    public abstract class Ranges
    {
        public int HeaderStart => 0;
        public virtual int HeaderLength { get; }
        public virtual int FilterStart { get; }
        public virtual int FilterLength { get; }
        public virtual int PartitionStart { get; }
        public virtual int PartitionLength { get; }
        public virtual int CompanyPrefixStart { get; }
        public virtual int SerialNumberLength { get; }
    }
}
