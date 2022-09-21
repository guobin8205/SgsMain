using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    class GsCUpdateHpNtf : BaseProtocol
    {
        enum EmMark
        {
            mark_normal_hurt = 1 << 0,     //普通伤害
            mark_fire_hurt = 1 << 1,     //火伤害
            mark_thurder_hurt = 1 << 2,     //雷伤害
            mark_chain_hurt = 1 << 3,     //传导伤害
            mark_lose_hp = 1 << 4,     //流失
            mark_hp_max = 1 << 5,       //hp上限
            mark_peculiar = 1 << 6,     //1v1特殊掉血
            mark_init = 1 << 7,     //初始血量
            mark_lose_shield = 1 << 8,      //流失护甲
        };

        public byte seatId;
        public int hp;//2.40 char-->short
        public byte murderSeatId;  //伤害来源
        public ushort spellId;     //造成伤害的spellId
        public uint mark;
        public short damage;       //本次伤害
        public short shield;        //护甲


        protected override void ReadParams()
        {
            seatId = ReadByte();
            hp = ReadInt();
            murderSeatId = ReadByte();
            spellId = ReadUShort();
            mark = ReadUInt();
            damage = ReadShort();
            shield = ReadShort();
        }

        bool IsNormalHurt() { return (0 != (mark & (uint)EmMark.mark_normal_hurt)); }
        bool IsFireHurt() { return (0 != (mark & (uint)EmMark.mark_fire_hurt)); }
        bool IsThurderHurt() { return (0 != (mark & (uint)EmMark.mark_thurder_hurt)); }
        bool IsChainHurt() { return (0 != (mark & (uint)EmMark.mark_chain_hurt)); }
        bool IsLoseHp() { return (0 != (mark & (uint)EmMark.mark_lose_hp)); }
        bool IsHpMax() { return (0 != (mark & (uint)EmMark.mark_hp_max)); }
        bool IsPeculiar() { return (0 != (mark & (uint)EmMark.mark_peculiar)); }
        bool IsInit() { return (0 != (mark & (uint)EmMark.mark_init)); }
        bool IsLoseShield() { return (0 != (mark & (uint)EmMark.mark_lose_shield)); }

    }
}
