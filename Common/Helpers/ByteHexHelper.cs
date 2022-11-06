using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class ByteHexHelper
    {
        private static char[] _buffedChars = null;
        private static byte[] _buffedBytes = null;
        static ByteHexHelper()
        {
            _buffedChars = new char[(byte.MaxValue - byte.MinValue + 1) * 2];
            int idx = 0;
            byte b = byte.MinValue;
            while (true)
            {
                string hexs = b.ToString("X2");
                _buffedChars[idx++] = hexs[0];
                _buffedChars[idx++] = hexs[1];
                if (b == byte.MaxValue) break;
                ++b;
            }

            _buffedBytes = new byte[0x67];
            idx = _buffedBytes.Length;
            while (--idx >= 0)
            {
                if ((0x30 <= idx) && (idx <= 0x39))
                {
                    _buffedBytes[idx] = (byte)(idx - 0x30);
                } else{
                    if ((0x61 <= idx) && (idx <= 0x66))
                    {
                        _buffedBytes[idx] = (byte)((idx - 0x61) + 10);
                        continue;
                    }
                    if ((0x41 <= idx) && (idx <= 70))
                    {
                        _buffedBytes[idx] = (byte)((idx - 0x41) + 10);
                    }
                }
            }
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHex(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            char[] result = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; ++i)
            {
                int startIndex = (bytes[i] - byte.MinValue) * 2;
                result[i * 2] = _buffedChars[startIndex];
                result[i * 2 + 1] = _buffedChars[startIndex + 1];
            }
            return new string(result);
        }

        /// <summary>
        /// 16进制字符串转字节数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] HexToByte(string str)
        {
            if (str == null || (str.Length & 1) == 1)
            {
                return null;
            }
            byte[] result = new byte[str.Length / 2];
            int charIndex = 0;
            int byteIndex = 0;
            int length = result.Length;
            while (--length >= 0)
            {
                int first = 0;
                int second = 0;
                try
                {
                    first = _buffedBytes[str[charIndex++]];
                    second = _buffedBytes[str[charIndex++]];
                }
                catch
                {
                    return null;
                }
                result[byteIndex++] = (byte)((first << 4) + second);
            }
            return result;
        }
    }
}
