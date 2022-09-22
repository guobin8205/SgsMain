using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotFix.Protocol
{
    public class GsCRoleOptNtf : BaseProtocol
    {
        public enum EmOpt
        {
            OPT_INVALID = 0,
            OPT_PLAY_CARD,           //出牌
            OPT_DISCARD,             //弃牌
        };


        public uint timeOut;         //时间条
        public byte seatId;           //操作的人的seatId
        public byte optType;          //要做操作的类型，通过枚举EmOpt中定义
        public uint param;           //用户定义数据
        public override void ReadParams()
        {
            timeOut = ReadUInt();
            seatId = ReadByte();
            optType = ReadByte();
            param = ReadByte();
        }
    }
}
