using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
namespace HotFix.Protocol
{
    /// <summary>
    /// 告诉其他人自己的身份（未完全迁移）
    /// </summary>
    class GameShowFigure :BaseProtocol
    {
        /// <summary>
        /// 查看身份的类型（死亡时显示、开局通知等）
        /// </summary>
        enum GameShowFigureType {
            TYPE_ASSIGN = 1,
            TYPE_NOTE = 2,
            TYPE_DIE = 3,
            TYPE_GAMEOVER = 4,
            TYPE_TANCHA = 5,//--探查身份結果
            TYPE_NEIJIAN_BEGIN = 6,//--内奸开局揭示的结果
        }
        /// <summary>
        /// 身份
        /// </summary>
        public byte figure;
        /// <summary>
        /// 座位号
        /// </summary>
        public byte seatId;
        /// <summary>
        /// GameShowFigureType
        /// </summary>
        public byte type;//类型
        public byte param = 0;
        public override void ReadParams()
        {
            base.ReadParams();
            figure = ReadByte();
            seatId = ReadByte();
            type = ReadByte();
        }
    }
}
