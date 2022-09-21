using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
namespace HotFix.Protocol
{
    /// <summary>
    /// 发武将牌
    /// </summary>
    class GameDealCharacter : BaseProtocol
    {
        /// <summary>
        /// 发武将牌的方式（选将、展示武将等）
        /// </summary>
        enum GameDealCharacterType {
            TYPE_SEL = 1,
            TYPE_WAIT = 2,
            TYPE_CHANGE = 3,
            TYPE_RECOMMEND = 4,
            TYPE_PRACTICE = 5,
            TYPE_NEW_1v1 = 6,
            TYPE_NEW_HAPPY_FIGHT = 7,//--展示武将
            TYPE_ARENA = 8,//--展示武将
            TYPE_CMEG_FORBID = 9,//--CMEG对手禁将
        }
        /// <summary>
        /// 武将id及其可选状态
        /// </summary>
        public class DealCharacter {
            public ushort uCharacterId;
            /// <summary>
            /// 0,不能用，1 普通可用，2 被禁用，3,6 体验卡 ，4 试用，5 开黑  7:共享  8:共享被禁
            /// </summary>
            public byte bMeetAssignCondition;
        }
        public List<DealCharacter> dealCharacter;
        public bool is_game_time_msg = true;
        public float recvTime;//add by chuck at 151223 for 选将超时不正确
        /// <summary>
        /// GameDealCharacterType
        /// </summary>
        public byte type;
        public uint timeOut;
        public ushort vip_card_cnt;
        protected override void ReadParams()
        {
            base.ReadParams();
            type = ReadByte();
            timeOut = ReadUInt();
            vip_card_cnt = ReadUShort();
            ushort _characterId;
            byte _isCondition;
            dealCharacter = new List<DealCharacter>();
            //max_sel_character,暂定为6
            for (int i = 0; i < 6; i++)
            {
                DealCharacter _dealCharacter = new DealCharacter();
                _characterId = ReadUShort();
                _isCondition = ReadByte();
                if (_characterId != 0)
                {
                    _dealCharacter.uCharacterId = _characterId;
                    _dealCharacter.bMeetAssignCondition = _isCondition;
                    dealCharacter.Add(_dealCharacter);
                }
            }
            
        }
    }
}
