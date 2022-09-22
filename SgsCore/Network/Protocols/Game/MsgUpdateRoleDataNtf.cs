using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    class MsgUpdateRoleDataNtf : BaseProtocol
    {
        enum EmDataId   //就一个人,最多能背负的RoleData为7
        {
            DATA_INVALID = 0,
            DATA_CAN_USE_SHA,           //是否可以出杀 (不包括连弩和咆哮 client要自己检查)(public)
            DATA_IS_BUQU_STATE,         //是否在不屈状态(周泰-不屈)
            DATA_IS_FIGURE_TAP,         //身份牌是否横置(public)
            DATA_IS_CHARCARD_TAP,       //武将牌是否横置(public)
            DATA_IS_CHARCARD_TURN_OVER, //武将牌是否翻面(public)
            DATA_IS_JIU_STATE,          //是否在酒状态(public)
            DATA_DEAL_CARD_ADD,         //下个摸牌阶段额外摸牌数
            DATA_CAN_JI_JIANG_CNT,      //是否能用激将技能(刘备-激将)
            DATA_RAO_SHE_MARK,          //饶舌标记
            DATA_IS_LUO_YI_STATE,       //是否在裸衣状态(许褚-裸衣)
            DATA_SHUANG_XIOING_RESULT,  //双雄的结果(颜良文丑-双雄)
            DATA_TIAN_YI_RESULT,        //天义的结果(太史慈-天义)
            DATA_ADD_EX_SPELL,          //给role添加技能 data为spell id(袁术-伪帝)
            DATA_NIE_PAN,               //是否使用过涅槃
            DATA_DEL_EX_SPELL,          //给role添加技能 data为spell id(袁术-伪帝)
            DATA_MENG_YAN_FLAG,         //梦魇标志
            DATA_ADD_GAME_WAIT_TIME,    //游戏中 增加游戏等待时间的次数
            DATA_BAO_NU_FLAG,           //狂暴标记
            DATA_JIU_USE_TIMES,         //本回合内酒使用的次数
            DATA_SHAN_JIA_STATE,        //缮甲状态
            DATA_FLAG_REN,              //忍戒标记
            DATA_LIAN_JI_MARK,          //连技标记
            DATA_LONG_MARK,             //龙印
            DATA_FENG_MARK,             //凤印
            DATA_JU_MARK,               //"橘"标记
            DATA_XIN_TIANYI,            //[应该没用到]
            DATA_ZHEN_FA_ZHAO_HUAN_TIMES, //阵法召唤的次数
            DATA_BAO_LI,                //"暴戾"标记
            DATA_JUN_LUE_MARK,          //"军略"标记
            DATA_SHAN_JIA_NEW_STATE,    //新"缮甲"标记
            DATA_MARK_HOU_TU,           //后土
            DATA_MARK_ZI_WEI,           //紫薇            
            DATA_MARK_YU_QING,          //玉清
            DATA_MARK_GOU_CHEN,         //勾陈
            DATA_CAUSE_DAMAGE_HP_PLAY_PHASE, //出牌阶段造成的伤害
            DATA_YING_MARK,             //营
            DATA_FU_MARK,               //辅
            DATA_WUKU_MARK,             //武库
            DATA_YUFENG_MARK,           //御风
            DATA_MAX,                   //ID的上限
                                        //不能超过255
        };

        public byte seatId;
        public byte dataId;
        public uint data;

        public override void ReadParams()
        {
            seatId = ReadByte();
            dataId = ReadByte();
            data = ReadUInt();
        }
    }
}
