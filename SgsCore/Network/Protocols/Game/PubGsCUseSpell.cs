using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    class PubGsCUseSpell: BaseProtocol
    {
		public byte srcSeatId;                        //使用武将技的人的seat id
		public byte destCount;                        //目标的个数
		public byte useCardCount;                     //使用的卡牌的个数
		public uint[] user_param = new uint[2];       //自定义数据(使用技能时 附加的数据)
		public ushort spellId;                         //武将的技能id
		public ushort seatId;                          //使用了那个角色的 和srcSeatId相同表示是自己的
		public ushort chrId;                           //使用的是那个武将的技能,0表示使用的是角色的武将技能
		public ushort spellIndex;                      //技能索引(不使用)
		public List<uint> datas = new List<uint>();             //！！注意：1.data中先是目标的seatid数据，目标可能是多个;2,然后是技使用的卡牌的id

        public override void WriteParams()
        {
			Write(srcSeatId);
			Write(destCount);
			Write(useCardCount);
			Write(user_param);
			Write(spellId);
			Write(seatId);
			Write(chrId);
			Write(spellIndex);
			Write(datas.ToArray());

		}

		protected override void ReadParams()
        {
			srcSeatId = ReadByte();
			destCount = ReadByte();
			useCardCount = ReadByte();
			user_param[0] = ReadUInt();
			user_param[1] = ReadUInt();
			spellId = ReadUShort();
			seatId = ReadUShort();
			chrId = ReadUShort();
			for(int i=0;i< destCount+ useCardCount;i++)
            {
				datas.Add(ReadUInt());

			}


		}
}
}
