using BenchmarkDotNet.Attributes;
using SgsCore.Managers;
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
        private HotFix.Protocol.PubGsCMoveCard moveCard1;
        private SgsCore.Network.ProtocolsNew.Game.PubGsCMoveCard moveCard2;
        private HotFix.Protocol.ClientLoginReq login1;
        private SgsCore.Network.ProtocolsNew.ClientLoginReq login2;
        private byte[] buf = null;
        [GlobalSetup]
        public void Init()
        {
            moveCard1 = new HotFix.Protocol.PubGsCMoveCard();
            moveCard2 = new SgsCore.Network.ProtocolsNew.Game.PubGsCMoveCard();
            buf = new byte[15] { 2,9,0,0,0,255,0,255,255,0,0,160,0,0,0};

            login1 = new HotFix.Protocol.ClientLoginReq();
            login2 = new SgsCore.Network.ProtocolsNew.ClientLoginReq();

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

        [Benchmark]
        public void TestLogin1()
        {
            login1.WriteParams();
            login1.ReadParams();
        }


        [Benchmark]
        public void TestLogin2()
        {
            ReadOnlySpan<byte> buffer = login2.Encode();
            login2.Decode(ref buffer);
        }
    }
}
