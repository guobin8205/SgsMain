using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    class GsCGamePhaseNtf : BaseProtocol
    {


        public byte curSeatId;    //当前阶段的seatID
        public byte phase;        //当前阶段
        protected override void ReadParams()
        {
            curSeatId = ReadByte();
            phase = ReadByte();
        }
    }
}
