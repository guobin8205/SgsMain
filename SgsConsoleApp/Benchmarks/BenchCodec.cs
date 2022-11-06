using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Loggers;
using SgsCore.Managers;
using SgsCore.Network.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsConsoleApp.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchCodec
    {
        //[Params(100, 1000, 10000)]
        //public int N;

        private HotFix.Protocol.PubGsCMoveCard moveCard1;
        private SgsCore.Network.ProtocolsNew.Game.PubGsCMoveCard moveCard2;
        private HotFix.Protocol.ClientLoginReq login1;
        private SgsCore.Network.ProtocolsNew.ClientLoginReq login2;
        private SgsCore.Network.ProtocolsNew.ClientLoginReq login3;
        private NetSerializer serializer = new NetSerializer();
        private byte[] buf = null;
        private byte[] buf2 = null;
        [GlobalSetup]
        public void Init()
        {
            moveCard1 = new HotFix.Protocol.PubGsCMoveCard();
            moveCard2 = new SgsCore.Network.ProtocolsNew.Game.PubGsCMoveCard();
            buf = new byte[15] { 2,9,0,0,0,255,0,255,255,0,0,160,0,0,0};

            login1 = new HotFix.Protocol.ClientLoginReq();
            login1.LoginType = 2;
            login1.LoginFrom = 1015;
            login1.NumberAccount = "aaaaaaa";
            login1.Username = "guobin82062013";
            login1.Password = "asdfsdfsdfs";
            login1.flistVer = "4.0.8|110110|6";
            login1.uuid = "UUID";
            login2 = new SgsCore.Network.ProtocolsNew.ClientLoginReq();
            login2.LoginType = 2;
            login2.LoginFrom = 1015;
            login2.NumberAccount = "aaaaaaa";
            login2.Username = "guobin82062013";
            login2.Password = "asdfsdfsdfs";
            login2.flistVer = "4.0.8|110110|6";
            login2.uuid = "UUID";
            login3 = new SgsCore.Network.ProtocolsNew.ClientLoginReq();
            login3.LoginType = 2;
            login3.LoginFrom = 1015;
            login3.NumberAccount = "aaaaaaa";
            login3.Username = "guobin82062013";
            login3.Password = "asdfsdfsdfs";
            login3.flistVer = "4.0.8|110110|6";
            login3.uuid = "UUID";
            Span<byte> buffer = stackalloc byte[1024];
            login2.Encode(buffer);

            buf2 = new byte[300];

        }


        //[Benchmark]
        //public void TestMoveCard1()
        //{
        //    moveCard1.SetBytes(buffer, buffer.Length, 21209);
        //}


        //[Benchmark]
        //public void TestMoveCard2()
        //{
        //    ReadOnlySpan<byte> buff = new ReadOnlySpan<byte>(buffer);
        //    moveCard2.Decode(ref buff);
        //}

        [Benchmark(Baseline = true)]
        public void TestLogin1()
        {
            login1.WriteParams();
            login1.ReadParams();
        }


        [Benchmark]
        public void TestLoginSpan()
        {
            Span<byte> buffer = stackalloc byte[1024];
            login2.Encode(buffer);
            login2.Decode(buffer);
        }

        [Benchmark]
        public void TestLoginAuto()
        {
            var buffer = serializer.Serialize<SgsCore.Network.ProtocolsNew.ClientLoginReq>(login3);
            serializer.Deserialize<SgsCore.Network.ProtocolsNew.ClientLoginReq>(new NetDataReader(buffer));
        }
    }
}
