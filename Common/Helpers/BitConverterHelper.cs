using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    internal class BitConverterHelper
    {
        [SecuritySafeCritical]
        public static unsafe int SingleToInt32Bits(float value)
        {
            return *(int*)(&value);
        }

        [SecuritySafeCritical]
        public static unsafe float Int32BitsToSingle(int value)
        {
            return *(float*)(&value);
        }
    }
}
