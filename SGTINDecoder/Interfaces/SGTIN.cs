using System;
using System.Collections.Generic;
using System.Text;

namespace SGTINDecoder.Interfaces
{
    public abstract class SGTIN
    {
        public abstract string SGTIN_Type { get; }
    }
}
