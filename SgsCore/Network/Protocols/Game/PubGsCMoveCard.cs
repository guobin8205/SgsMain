using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
namespace HotFix.Protocol
{
    /// <summary>
    /// 移动卡牌(未完全迁移)
    /// </summary>
    public class PubGsCMoveCard :BaseProtocol
    {
        /// <summary>
        /// 源区域
        /// </summary>
        public byte fromZone;
        public byte toZone;
        /// <summary>
        /// 源的id（seatid）
        /// </summary>
        public byte fromId;
        public byte toId;
        /// <summary>
        /// 源的位置
        /// </summary>
        public ushort fromPosition;
        public ushort toPosition;
        /// <summary>
        /// 发起移动动作的seatId
        /// </summary>
        public byte srcSeatId;
        /// <summary>
        /// 引起移动的技能id
        /// </summary>
        public ushort spellId;
        /// <summary>
        /// 有些区域需要(场外，技能区域)
        /// </summary>
        public ushort fromZoneParam;
        public ushort toZoneParam;
        /// <summary>
        /// 卡牌数量
        /// </summary>
        public ushort cardCnt;
        /// <summary>
        /// 数据数量（只有已知卡牌有数据）
        /// </summary>
        public ushort dataCnt;
        /// <summary>
        /// 已知卡牌id
        /// </summary>
        public List<uint> data = new List<uint>();

        public override void ReadParams()
        {
            base.ReadParams();
            fromZone = ReadByte();
            toZone = ReadByte();
            fromId = ReadByte();
            toId = ReadByte();
            fromPosition = ReadUShort();
            toPosition = ReadUShort();
            srcSeatId = ReadByte();
            spellId = ReadUShort();
            //fromZoneParam = ReadUShort();
            //toZoneParam = ReadUShort();
            cardCnt = ReadUShort();
            dataCnt = ReadUShort();
            for (int i = 0; i < dataCnt; i++)
            {
                uint _tempData = ReadUShort();
                data.Add(_tempData);
            }
        }

        public override void WriteParams()
        {
            Write(fromZone);
            Write(toZone);
            Write(fromZone);
            Write(toId);
            Write(fromPosition);
            Write(toPosition);
            Write(srcSeatId);
            Write(spellId);
            Write(fromZoneParam);
            Write(toZoneParam);
            Write(cardCnt);
            Write(dataCnt);
            
            for(int i = 0; i < dataCnt; i++)
            {
                Write(data[i]);
            }
        }
    }
}
