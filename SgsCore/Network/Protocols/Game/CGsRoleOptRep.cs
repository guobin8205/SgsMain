
using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    class CGsRoleOptRep : BaseProtocol
    {
        public enum EmOpt:ushort
        {
            OPT_INVALID = 0,
            OPT_PLAY_CARD,           //出牌
            OPT_DISCARD,             //弃牌
        };

        public byte seatId;
        public ushort optType;     //请求操作的类型，EmOpt定义
        public override void WriteParams()
        {
            Write(seatId);
            Write(optType);

        }
    }
}
