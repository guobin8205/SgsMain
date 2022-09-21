using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    class MsgRemoveTimeBarNtf : BaseProtocol
    {
        public byte seatId;    //当前阶段的seatID

        protected override void ReadParams()
        {
            seatId = ReadByte();

        }
    }
}
