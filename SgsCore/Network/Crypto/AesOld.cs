using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.Crypto
{
    public class AesOld
    {


        static Byte[] DefalutAesKey =                    {
            0xF3, 0x62, 0x12, 0x05, 0x13, 0xE3, 0x89, 0xFF,
            0x23, 0x11, 0xD7, 0x36, 0x01, 0x23, 0x10, 0x07,
            0x05, 0xA2, 0x10, 0x00, 0x7A, 0xCC, 0x02, 0x3C,
            0x39, 0x01, 0xDA, 0x2E, 0xCB, 0x12, 0x44, 0x8B
        };


        static Byte[] gAesIV =
        {
              0x15, 0xFF, 0x01, 0x00, 0x34, 0xAB, 0x4C, 0xD3,
             0x55, 0xFE, 0xA1, 0x22, 0x08, 0x4F, 0x13, 0x07
        };

        /// <summary>
        /// 获取密钥
        /// </summary>
        private static string Key
        {
            get { return System.Text.Encoding.ASCII.GetString(DefalutAesKey); }
        }

        /// <summary>
        /// 获取向量
        /// </summary>
        private static string IV
        {
            get { return System.Text.Encoding.ASCII.GetString(gAesIV); }
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <returns>密文</returns>
        public static byte[] AESEncrypt(byte[] byteArray)
        {
            byte[] bKey = DefalutAesKey;
            byte[] bIV = gAesIV;
            //byte[] byteArray = Encoding.UTF8.GetBytes(plainStr);

            byte[] encrypt = null;
            byte[] newencrypt = new byte[byteArray.Length];
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.CFB;
            aes.Padding = PaddingMode.Zeros;
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = mStream.ToArray();

                        Array.Copy(encrypt, newencrypt, byteArray.Length);
                    }
                }
            }
            catch { }
            aes.Clear();

            return newencrypt;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>密文</returns>
        public static byte[] AESEncrypt(byte[] plainStr, bool returnNull)
        {
            byte[] encrypt = AESEncrypt(plainStr);
            return returnNull ? encrypt : (encrypt == null ? null : encrypt);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <returns>明文</returns>
        public static byte[] AESDecrypt(byte[] byteArray)
        {
            byte[] bKey = DefalutAesKey;
            byte[] bIV = gAesIV;
            //byte[] byteArray = Convert.FromBase64String(encryptStr);

            byte[] decrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.CFB;
            aes.Padding = PaddingMode.None;
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        int len = (byteArray.Length / gAesIV.Length);
                        if (len * gAesIV.Length == byteArray.Length)
                        {
                            len = byteArray.Length;
                        }
                        else
                        {
                            len = (len + 1) * gAesIV.Length;
                        }
                        byte[] newarray = new byte[len];
                        Array.Copy(byteArray, newarray, byteArray.Length);
                        cStream.Write(newarray, 0, newarray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = mStream.ToArray();
                    }
                }
            }
            catch { }
            aes.Clear();

            return decrypt;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>明文</returns>
        public static byte[] AESDecrypt(byte[] byteArray, bool returnNull)
        {
            byte[] decrypt = AESDecrypt(byteArray);
            return returnNull ? decrypt : (decrypt == null ? null : decrypt);
        }
    }
}
