using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotFix.Protocol
{
    class GsCTriggerSpellEnq:BaseProtocol
    {
        uint timeOut;                     //时间条
        byte triggerSeatId;                //被触发技能的角色seatid
        byte targetSeatId;                 //目标角色seatid
        byte srcSpellCasterSeat;          //引起操作的技能的触发者seatId，可能为无效值(client提示用)
        ushort srcSpellId;                  //引起触发的技能id，可能空0；
        ushort [] triggerSpellId;              //被触发的技能id
        byte paramcnt;
        List<uint> paramDatas;

        protected override void ReadParams()
        {
            timeOut = ReadUInt();
            triggerSeatId = ReadByte();
            targetSeatId = ReadByte();
            srcSpellCasterSeat = ReadByte();
            srcSpellId = ReadUShort();
            triggerSpellId = new ushort[MaxLength.max_triggerspell];
            for(int i = 0 ; i < MaxLength.max_triggerspell ; ++i)
            {
                triggerSpellId[i] = ReadUShort();
            }
            paramcnt = ReadByte();
            paramDatas = new List<uint>();
            for (int i = 0; i < paramcnt; ++i)
            {
                if (BytesAvailable < 4)
                    break;
                paramDatas.Add(ReadUInt());
            }

        }
    }


}
