using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
namespace HotFix.Protocol
{
    /// <summary>
    /// 设置武将（这个原版里同时有read和write）
    /// （未完全迁移）
    /// </summary>
    class GameSetCharacter:BaseProtocol
    {
        /// <summary>
        /// 武将信息（座位、武将id、势力）
        /// </summary>
        public class CharaInfo {
            /// <summary>
            /// 座位id
            /// </summary>
            public byte seatId;
            /// <summary>
            /// 武将id
            /// </summary>
            public ushort charaId;
            /// <summary>
            /// 所属势力
            /// </summary>
            public byte country;
        }
        public byte count;
        /// <summary>
        /// 设置武将列表，可设置多个座位的武将信息
        /// </summary>
        public List<CharaInfo> charaInfo;
        protected override void ReadParams()
        {
            base.ReadParams();
            count = ReadByte();
            charaInfo = new List<CharaInfo>();
            for (int i = 0; i < count; i++)
            {
                CharaInfo _charaInfo = new CharaInfo();
                _charaInfo.seatId = ReadByte();
                _charaInfo.charaId = ReadUShort();
                _charaInfo.country = ReadByte();
                charaInfo.Add(_charaInfo);
            }
        }
    }
}
