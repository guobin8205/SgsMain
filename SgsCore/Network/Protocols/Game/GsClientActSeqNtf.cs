using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
namespace HotFix.Protocol
{
    /// <summary>
    /// 行动顺序
    /// </summary>
    class GsClientActSeqNtf : BaseProtocol
    {
        public byte count;
        /// <summary>
        /// 每个位置的先后顺序
        /// </summary>
        public List<uint> seats=new List<uint>(); 
        protected override void ReadParams()
        {
            base.ReadParams();
            count = ReadByte();
            for (int i = 0; i < count; i++)
            {
                uint _seatId = ReadUInt();
                seats.Add(_seatId);
            }
        }

    }
}
