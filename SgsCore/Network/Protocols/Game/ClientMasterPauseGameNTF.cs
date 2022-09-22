using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;

namespace HotFix.Protocol
{
    /// <summary>
    /// 暂停或回复游戏协议返回(未完全迁移，版本未判断)
    /// </summary>
    class ClientMasterPauseGameNTF :BaseProtocol
    {
        public byte pause;
        public string operator_nick;
        /// <summary>
        /// 暂停开始时间
        /// </summary>
        public uint pause_start;
        /// <summary>
        /// 暂停时间
        /// </summary>
        public uint pause_time;
        public bool user_op;
        //event_id: 1 (王战比赛在开始的时候可能需要暂停)
        public uint event_id;
        public byte length;
        public override void ReadParams()
        {
            base.ReadParams();
            pause = ReadByte();
            length = ReadByte();
            operator_nick = ReadString(length);
            pause_start = ReadUInt();
            pause_time = ReadUInt();
            user_op = ReadBool();
            event_id = ReadUInt();
        }
    }
}
