using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    public class GsCRoleOptTargetNtf : BaseProtocol
    {
        enum EmOpt
        {
            OPT_INVALID = 0,

            OPT_SEL_CARD_TARGET,    //要求从 目标所有牌(判定、手牌、装备)中 选择一张
            OPT_SEL_CARD_HAND_EQUIP,//要求从 目标(手牌、装备)中 选择一张
            OPT_SEL_CARD_HAND,      //要求从 目标(手牌)中 选择一张
            OPT_DISCARD_TARGET_HAND,//要求弃掉目标一张手牌

            OPT_CI_XIONG_JIAN,       //雌雄双股剑
            OPT_SEL_CARD_SPELLZONE,  //从技能区选择(观星/心战)
            OPT_SHAN,                //要求打出/使用"闪"
            OPT_SHA,                 //要求打出/使用"杀"
            OPT_WUGU,                //五谷丰登
            OPT_QILIN,               //麒麟弓
            OPT_YIJI,                //遗计
            OPT_GANGLIE,            //刚烈
            OPT_LUOSHEN,            //洛神
            OPT_SELCOLOR,           //选择花色
            OPT_SEL_BUQU,           //选择一张不屈牌
            OPT_ZHIYI,              //质疑(蛊惑)
            OPT_HUJIA,              //护驾
            OPT_KEJI,               //克己的牌超过20张 请弃掉一些牌
            OPT_TARGET,             //指明目标
            OPT_PINNUM,             //拼点
            OPT_BAGUAZHEN,          //八阵-询问-八卦阵
            OPT_DEALCARD,           //是否摸牌
            OPT_SEL_CARD_JUDGE,     //要求从 目标(判定)中 选择一张
            OPT_SEL_ACT = 24,           //选择行动
            OPT_GET_CARD = 25,          //询问是否要获得指定的卡牌
            OPT_ASK_FACE_UP_CHARACTER = 27, //询问翻将(国战)
            OPT_COMMON_1 = 28,//通用询问操作，根据不同技能不同处理
            OPT_COMMON_2 = 29,//通用询问操作，根据不同技能不同处理
            OPT_COMMON_3 = 30,//通用询问操作，根据不同技能不同处理
            OPT_FIRST_GENERAL_FACE_UP_ZHU_LIAN_BI_HE = 31,//珠联璧合
            OPT_FIRST_GENERAL_FACE_UP_HALF_HP_DEAL_CARD = 32,//半血摸牌
            OPT_FIRST_FACE_UP_GENERAL_DEAL_CARD_IN_GAME = 33,//游戏中第一个翻将新闻
            OPT_SEL_CARD_MI = 34,   //选择一张米牌
            OPT_DOUDIZHU_MULTIPLE = 36,     // 斗地主-询问/通知叫倍数
            OPT_DOUDIZHU_CHOOSE_HP_CARD = 37,   // 斗地主-农民死后询问另一农民回血或摸牌
            OPT_ARENA_CHANGE_CARD = 38,         // 排位赛 要求4号位换牌
                                                //OPT_ZHEN_FA_ASK = 39,					//阵法技-阵法询问
            OPT_ZHEN_FA_ASK_SHOW_CHARACTER = 39,    //阵法技-亮将请求
            OPT_COMMON_4 = 40,
            OPT_REPLACE_VICE = 41,             // 国战,要求更换副将
            OPT_WAIT_DONOTHING = 42,
            OPT_MILITARY_ORDER = 43,    //军令选择
            OPT_ZHUAN_HUA = 44,  //转换效果
            OPT_CHANGE_COUNTRY = 45,  //选择更换势力
            OPT_COMMON_5 = 46,//通用询问操作，根据不同技能不同处理
            OPT_CHESS_SEL_CHAR = 100,
            OPT_CHESS_DYING_PRAY = 101,
            OPT_END,
        };

        uint timeOut;         //时间条
        byte optSeatId;        //被要求做动作的人的seatId
        byte targetSeatId;     //他的目标的seatId
        byte spellCasterSeat;  //引起操作的技能id的使用者seatid(client提示用)
        ushort spellId;         //引起操作的技能id
        ushort optType;         //要做的动作，EmOpt定义
        uint param;           //用户定义数据
        uint param2;
        ushort dataCnt;
        public List<uint> datas;

        public override void ReadParams()
        {
            timeOut = ReadUInt();
            optSeatId = ReadByte();
            targetSeatId = ReadByte();
            spellCasterSeat = ReadByte();
            spellId = ReadUShort();
            optType = ReadUShort();
            param = ReadUInt();
            param2 = ReadUInt();
            dataCnt = ReadUShort();
            datas = new List<uint>();
            for (int i = 0; i < dataCnt; ++i)
            {
                if (BytesAvailable < 4)
                    break;
                datas.Add(ReadUInt());
            }

        }
    }
}
