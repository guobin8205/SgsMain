using BenchmarkDotNet.Attributes;
using SgsCore.Network.Crypto;
using SgsCore.Network.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsConsoleApp.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkAes
    {
        private byte[] testdata = new byte[] { 245, 97, 165, 34, 238, 239, 63, 237, 75 };
        byte[] outdata = new byte[9];

        [Benchmark]
        public void AesDecrypt1()
        {
            outdata = AesOld.AESDecrypt(testdata);
        }

        [Benchmark]
        public void AesDecrypt2()
        {
            AesCryptor.Decrypt(testdata, outdata, testdata.Length);
        }
        [Benchmark]
        public void AesEncrypt1()
        {
            outdata = AesOld.AESEncrypt(testdata);
        }

        [Benchmark]
        public void AesEncrypt2()
        {
            AesCryptor.Encrypt(testdata, outdata, testdata.Length);
        }

    }
}
