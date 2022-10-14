using Common.Extensions.SpanExt;
using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew.Game
{
    public class PubGsCMoveCard : ProtocolBase
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

        public override bool Decode(ref ReadOnlySpan<byte> buffer)
        {
            fromZone = buffer.MoveReadByte();
            toZone = buffer.MoveReadByte();
            fromId = buffer.MoveReadByte();
            toId = buffer.MoveReadByte();
            fromPosition = buffer.MoveReadUShort();
            toPosition = buffer.MoveReadUShort();
            srcSeatId = buffer.MoveReadByte();
            spellId = buffer.MoveReadUShort();
            //fromZoneParam = buffer.MoveReadUShort();
            //toZoneParam = buffer.MoveReadUShort();
            cardCnt = buffer.MoveReadUShort();
            dataCnt = buffer.MoveReadUShort();
            for (int i = 0; i < dataCnt; i++)
            {
                data.Add(buffer.MoveReadUShort());
            }
            return true;
        }

        public override Span<byte> Encode()
        {
            throw new NotImplementedException();
        }


        //protected override void WriteParams()
        //{
        //    Write(fromZone);
        //    Write(toZone);
        //    Write(fromZone);
        //    Write(toId);
        //    Write(fromPosition);
        //    Write(toPosition);
        //    Write(srcSeatId);
        //    Write(spellId);
        //    Write(fromZoneParam);
        //    Write(toZoneParam);
        //    Write(cardCnt);
        //    Write(dataCnt);

        //    for (int i = 0; i < dataCnt; i++)
        //    {
        //        Write(data[i]);
        //    }
        //}
    }
}
