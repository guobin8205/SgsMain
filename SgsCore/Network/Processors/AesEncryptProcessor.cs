using SgsCore.Network.Crypto;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace SgsCore.Network.Processors
{
    public class AesEncryptProcessor
    {
        public static readonly byte[] _gszDefalutAesKey = { (byte) 0xF3, 0x62, 0x12, 0x05, 0x13,
            (byte) 0xE3, (byte) 0x89, (byte) 0xFF, 0x23, 0x11, (byte) 0xD7,
            0x36, 0x01, 0x23, 0x10, 0x07, 0x05, (byte) 0xA2, 0x10, 0x00, 0x7A,
            (byte) 0xCC, 0x02, 0x3C, 0x39, 0x01, (byte) 0xDA, 0x2E,
            (byte) 0xCB, 0x12, 0x44, (byte) 0x8B };
        public static readonly byte[] _gAesIV = { 0x15, (byte) 0xFF, 0x01, 0x00, 0x34, (byte) 0xAB,
            0x4C, (byte) 0xD3, 0x55, (byte) 0xFE, (byte) 0xA1, 0x22, 0x08,
            0x4F, 0x13, 0x07 };

        private readonly AesCryptoServiceProvider _aes;
        private byte[] cipherBuffer = new byte[1500];
        public const int KeySize = 256;
        public const int BlockSize = 128;
        private ICryptoTransform _encryptor;
        private ICryptoTransform _decryptor;

        public AesEncryptProcessor()
        {
            _aes = new AesCryptoServiceProvider();
            //_aes.KeySize = KeySize;
            //_aes.BlockSize = BlockSize;
            _aes.Mode = CipherMode.CFB;
            _aes.Padding = PaddingMode.PKCS7;
            _aes.Key = _gszDefalutAesKey;
            _aes.IV = _gAesIV;

            _encryptor = _aes.CreateEncryptor();
            _decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);

            //Rijndael aes = Rijndael.Create();
            //aes.Mode = CipherMode.CFB;
            //aes.Padding = PaddingMode.None;
            //_decryptor = aes.CreateEncryptor(DefalutAesKey, gAesIV);
            //_decryptor = aes.CreateEncryptor(DefalutAesKey, gAesIV);
        }

        public void ProcessInboundPacket(Buffer data, int offset, int length)
        {
            AesCryptor.Decrypt(data.Data, offset, data.Data, offset, length);
        }

        public void ProcessOutBoundPacket(byte[] data, int offset, int length)
        {
            AesCryptor.Encrypt(data, offset, data, offset, length);
        }
    }
}
