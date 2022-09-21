using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;

namespace HotFix.Protocol
{
    /// <summary>
    /// 选择武将
    /// </summary>
    class GameSelectCharacterReq:BaseProtocol
    {
        public ushort uCharacterId = 1;
        public override void WriteParams()
        {
            base.WriteParams();
            Write(uCharacterId);
        }
    }
}
