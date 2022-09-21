using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.Protocols
{
    public class MaxLength
    {
        public const int NICKNAME = 40;
        public const int TABLE_NAME = 50;
        public const int TABLE_PASSWORD = 16;
        public const int LOGIN_ACCOUNT = 48;
        public const int LOGIN_PASSWORD = 48;
        public const int IP = 16;
        public const int NICKNAME_TEXTINPUT = 12;
        public const int NICKNAME_SHOW_LENGTH = 20;
        public const int MAX_GUILDNAME_LEN = 32;
        public const int MAX_GUILD_NOTICE_LEN = 304;
        public const int MAX_GUILD_DECLARATION_LEN = 204;
        public const int SC_MAX_REALPT_LEN = 50;
        public const int MAX_DULPWD_LENGTH = 33;
        public const int MAX_TICKET_LENGTH = 64;
        public const int MAX_HEADLINK_LENGTH = 64;
        public const int sc_max_feeling_words_len = 60;
        /// <summary>
        /// XGeneralPatchItem 最大数组长度
        /// </summary>
        public const int SC_MAX_GENERAL_COUNT = 300;

        public const int max_triggerspell = 3;
    }

    public class ProtocolDictionary
    {
        private static ProtocolDictionary instance = null;
        private ProtocolDictionary()
        {

            ProtocolID[] values = Enum.GetValues(typeof(ProtocolID)) as ProtocolID[];
            foreach (ProtocolID value in values)
            {
                string name = "HotFix.Protocol." + Enum.GetName(typeof(ProtocolID), value);
                ProtocolDicName2ID[name] = (int)value;
                ProtocolDicID2Name[(int)value] = name;
                ProtocolDicID2Type[(int)value] = Type.GetType(name);

            }
        }
        static public ProtocolDictionary GetInstance()
        {
            if (instance == null)
            {
                instance = new ProtocolDictionary();
            }
            return instance;
        }
        public Dictionary<int, string> ProtocolDicID2Name = new Dictionary<int, string>();
        public Dictionary<string, int> ProtocolDicName2ID = new Dictionary<string, int>();
        public Dictionary<int, Type> ProtocolDicID2Type = new Dictionary<int, Type>();
    }
    /// <summary>
    /// unique protocol id that should be same on server and client
    /// </summary>
    public enum ProtocolID
    {
        //SSClientHappy1v1MatchNtf = 23606,
        //      HandScoreNtf = 21482,
        //      ClientCModelMkTblReq = 20545,
        //      ClientCModelMkTblRep = 20546,
        SsClientVersionNtf = 20017,
        //      DbsCcPrivilegedIpNtf = 20242,
        MsgHeartAliveReq = 21102,
        MsgHeartAliveRep = 21103,
        ClientLoginReq = 20201,
        ClientLoginRep = 20202,
        //      ClientCheckNkMayuseReq = 20325,
        //      ClientCheckNkMayuseRep = 20326,
        //      ClientCreateRoleReq = 20301,
        //      ClientTrainingReq = 20420,
        //      ClinetNetSpeedNtf = 21423,
        //      ClientUserbaseinfoReq = 21404,
        //      ClientUserbaseinfoRep = 21405,
        ClientEnterpageReq = 20401,
        ClientEnterpageRep = 20402,
        //      ClientSitdownRep = 20504,
        //      ClientLogoutReq = 20205,
        //      DbsCsClientCreateRoleRsp = 20208,
        ClientCreatetableReq = 20501,
        ClientCreatetableRep = 20502,
        ClientLeaveTableReq = 20505,//离开房间
        ClientLeaveTableRep = 20506,
        ClientTableInfoReq = 20507,
        ClientTableInfoRep = 20508,
        ClientIpReq = 20534,
        ClientIpRep = 20535,
        ClientMasterPauseGameNTF = 20559,//暂停或回复游戏协议返回
        GsClientActSeqNtf = 20567,//行动顺序
        DbsClientUpdateUserYuanBaoNtf = 20801, //元宝变化通知
        ClientUserDetailReq = 21402, //玩家详细信息请求
        ClientUserDetailRep = 21403, //玩家详细信息
        ClientUserBaseInfoReq = 21404, //玩家基础信息请求
        ClientUserBaseInfoRep = 21405, //玩家基础信息回包
        ClientSelfBuyGeneralReq = 21420, //获取个人所有用的武将
        ClientSelfBuyGeneralRep = 21421, //获取武将信息返回
        ClientSSBussinessCardReq = 21657, //个人名片信息请求
        SSClientBussinessCardRep = 21658, //个人名片信息返回

        ///GS 协议 BEGIN
        CGSStartGameRep = 21207,
        ModifyUserSeatNtf = 21208,//game 开始
        PubGsCMoveCard = 21209,//移动卡牌（双向read、write）
        PubGsCUseCard = 21210,//使用卡牌
        PubGsCUseSpell = 21212,//使用技能
        GsCGamePhaseNtf = 21213, ////通知游戏阶段
        GsCRoleOptNtf,  //通知角色操作
        GsCRoleOptTargetNtf, //通知角色对目标操作
        GsCUpdateHpNtf, //更新血量
        GsCTriggerSpellEnq, //询问是否触发技能
        MsgUpdateRoleDataNtf = 21218, //更新玩家数据
        CGsRoleOptRep,  //role操作回复
        CGsRoleSpellOptRep, //role对spell操作回复
        GameShowFigure = 21223,//告诉其他人自己的身份
        GameDealCharacter = 21224,//发武将牌
        GameSelectCharacterReq = 21225,//选择武将
        GameSetCharacter = 21227,//设置武将
        MsgUpdateRoleDataExNtf = 21252, //更新玩家数据
        GsCTriggerSpellNew = 21265, //技能触发
        GsClientDealZoneSizeNtf = 21368,//牌堆牌数
        MsgRemoveTimeBarNtf = 21371, //移除事件条
        //GS 协议 END
        GS_END
    }
}
