using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    public struct TriggerParam
    {
        public byte index;//触发列表中的索引
        public ushort spellId;//触发的技能
        public byte count;//触发的次数
        public byte seatId;
        public ushort chrId;
        public byte mark;//标志
        public byte targetCnt;
        public byte cardCnt;
        public byte dataCnt;//uDataCnt >=1,uDataCnt最后一个数据用来表示触发的是技能的那个效果
        public List<uint> targetData;//变长数据，按照技能的顺序,存放的参数列表
        public List<uint> cardData;
        public List<uint> dataData;

        public void ReadParams(BaseProtocol protocol)
        {
            index = protocol.ReadByte();
            spellId = protocol.ReadUShort();
            count = protocol.ReadByte();
            seatId = protocol.ReadByte();
            chrId = protocol.ReadUShort();
            mark = protocol.ReadByte();
            targetCnt = protocol.ReadByte();
            cardCnt = protocol.ReadByte();
            dataCnt = protocol.ReadByte();
            targetData = new List<uint>();
            for (int i = 0; i < targetCnt; ++i)
            {
                targetData.Add(protocol.ReadUInt());
            }
            cardData = new List<uint>();
            for (int i = 0; i < cardCnt; ++i)
            { 
                cardData.Add(protocol.ReadUInt());
            }
            dataData = new List<uint>();
            for (int i = 0; i < dataCnt; ++i)
            {
                dataData.Add(protocol.ReadUInt());
            }
        }


    };

    class GsCTriggerSpellNew : BaseProtocol
    {
        public uint timeOut;                     //时间条
        public byte triggerSeatId;                //操作者的seatId;
        public byte srcSpellCasterSeat;          //引起操作的技能的触发者seatId，可能为无效值(client提示用)
        public ushort srcSpellCasterChrId;            //引起操作的技能的触发者武将ID
        public ushort srcSpellId;                  //引起触发的技能id，可能空0；
        public byte uTriggerSpellCnt;
        public List<TriggerParam> triggerParam;//被触发的技能 变长数据

        protected override void ReadParams()
        {
            timeOut = ReadUInt();
            triggerSeatId = ReadByte();
            srcSpellCasterSeat = ReadByte();
            srcSpellCasterChrId = ReadUShort();
            srcSpellId = ReadUShort();
            uTriggerSpellCnt = ReadByte();

            triggerParam = new List<TriggerParam>();
            for (int i = 0; i < uTriggerSpellCnt; ++i)
            {
                TriggerParam param = new TriggerParam();
                param.ReadParams(this);
                triggerParam.Add(param);
            }

        }
    }
}
