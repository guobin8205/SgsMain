using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    class PubGsCUseCard :BaseProtocol
    {
		public byte srcSeatId;            //使用技能的seatid
		public uint cardId;              //使用的卡牌
		public ushort spellId;             //使用的具体卡牌技能(客户端提示用)
		public byte fromZone;             //使用的是那个区域的牌,默认是手牌(客户端提示用)
		public byte mode;                  //使用还是打出 1 使用，2 打出
		public bool enhanced;               //是否是 "谋攻篇 怒"
		public byte destCnt;              //目标的个数
		public byte paramCnt;             //参数个数(Card自定义)
        public List<byte> datas = new List<byte>();   //目标的seatid

        public override void WriteParams()
        {
			Write(srcSeatId);
			Write(cardId);
			Write(spellId);
			Write(fromZone);
			Write(mode);
			Write(enhanced);
			Write(destCnt);
			Write(paramCnt);
			Write(datas.ToArray());
		}

		protected override void ReadParams()
        {
			srcSeatId = ReadByte();
			cardId = ReadUInt();
			spellId = ReadUShort();
			fromZone = ReadByte();
			mode = ReadByte();
			enhanced = ReadBool();
			destCnt = ReadByte();
			paramCnt = ReadByte();
			for (int i = 0; i < destCnt + paramCnt; i++)
			{
				datas.Add(ReadByte());

			}
		}

	}
}
