using SgsCore.GameSystem;
using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    public class ModifyUserSeatNtf : BaseProtocol
    {

        public struct TSeatInfo
        {
            public uint userTmpId;
            public byte seatId;   //座位号
            public TSeatInfo(uint userTmpId = GameConst.INVALID_USER_TEMP_ID, byte seatId = GameConst.INVALID_SEAT_ID)
            {
                this.userTmpId = userTmpId;
                this.seatId = seatId;
            }
        };

        public bool IsGameBegin; //==true,游戏开始,false游戏结束，
        public List<TSeatInfo> SeatInfos;
        public uint Model;
        public uint Section;

        protected override void ReadParams()
        {
            IsGameBegin = ReadBool();
            SeatInfos = new List<TSeatInfo>();

            for (int i = 0; i < GameConst.MAX_SEAT_NUM; ++i)
            {
                uint userTmpId = ReadUInt();
                byte seatId = ReadByte();
                if (seatId != GameConst.INVALID_SEAT_ID && userTmpId != GameConst.INVALID_USER_TEMP_ID)
                {
                    TSeatInfo info = new TSeatInfo(userTmpId, seatId);
                    SeatInfos.Add(info);
                }
            }

            Model = ReadUInt();
            Section = ReadUInt();
        }
    }
}
