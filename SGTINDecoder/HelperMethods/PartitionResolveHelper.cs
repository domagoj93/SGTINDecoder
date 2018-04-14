using System;
using System.Collections.Generic;
using System.Text;

namespace SGTINDecoder.HelperMethods
{
    public static class PartitionResolveHelper
    {
        public static (int CompanyPrefixBitsCount, int ItemReferenceBitsCount) GetCompanyPrefixAndItemReference(int partition)
        {
            switch (partition)
            {
                case 0:
                    return (40, 4);
                case 1:
                    return (37, 7);
                case 2:
                    return (34, 10);
                case 3:
                    return (30, 14);
                case 4:
                    return (27, 17);
                case 5:
                    return (24, 20);
                case 6:
                    return (20, 24);
                default:
                    return (0, 0);
            }
        }
    }
}
