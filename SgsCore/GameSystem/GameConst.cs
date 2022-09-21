using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.GameSystem
{
    public class GameConst
    {
        public const int INVALID_USER_TEMP_ID = 0;//无效用户ID
        public const int INVALID_SEAT_ID = 255; //无效座位号
        public const int INVALID_ORDER_INDEX = 255;//无效出牌顺序

        public const int MAX_SEAT_NUM = 8;//最大座位数，这个同GS约定写死

        public enum CardSuit
        {
            SUIT_INVALID = 0,      //无效类型
            /// <summary>
            /// 红桃
            /// </summary>
            SUIT_HEART = 1,
            /// <summary>
            /// 方块
            /// </summary>
            SUIT_DIAMOND = 2,
            /// <summary>
            /// 黑桃
            /// </summary>
            SUIT_SPADE = 3,
            /// <summary>
            /// 梅花
            /// </summary>
            SUIT_CLUB = 4,
            SUIT_MAX,
        }

        public enum PlayCardColor
        {
            PLAYCARD_COLOR_NONE = 0,//无色
            PLAYCARD_COLOR_RED,//红色
            PLAYCARD_COLOR_BLACK,//黑色
            PLAYCARD_COLOR_COUNT
        }

        public enum CardBaseType
        {
            CARD_TYPE_INVALID = 0,        //无效类型
            CARD_TYPE_NORMAL = 1,        //普通
            CARD_TYPE_STRATAGEM = 2,        //锦囊
            CARD_TYPE_EQUIP = 3,        //装备
            CARD_TYPE_CHARACTER = 4,        //武将
            CARD_TYPE_SCHEME = 5,       //计谋
            CARD_TYPE_MAX,
        }

        public enum CardSubType
        {
            CARD_SUB_TYPE_INVALID = 0,    //无效类型
            CARD_SUB_TYPE_WEAPON = 1,    //武器
            CARD_SUB_TYPE_ARMOR = 2,    //防具
            CARD_SUB_TYPE_DEF_HORSE = 3,    //防御马+1
            CARD_SUB_TYPE_ATT_HORSE = 4,    //进攻马-1
            CARD_SUB_TYPE_DELAY_STRA = 5,    //延时锦囊
            CARD_SUB_TYPE_FIRE_SHA = 6,    //火杀
            CARD_SUB_TYPE_THUNDER_SHA = 7,    //雷杀
            CARD_SUB_TYPE_WU_XIE_GUO = 8,   //无懈可击 国
            CARD_SUB_TYPE_TREASURE = 9, //宝物
            CARD_SUB_TYPE_CI_SHA = 10,  //刺杀
            CARD_SUB_TYPE_COUNTRY_STRA = 11,    //势力锦囊
            CARD_SUB_TYPE_YUE_GUI_JIU = 101,    //月桂酒
            CARD_SUB_TYPE_XUE_QIU = 102,    //雪球
            CARD_SUB_TYPE_MAX,
        }

        /// <summary>
        /// 显示堆叠区类型
        /// </summary>
        public enum ShowStackType
        {
            STACK_SHOWING, //展示
            STACK_CHOOSE, //选牌
            STACK_MOVE_UPDOWN, //上下移动
            STACK_MOVE_LEFT_RIGHT //左右移动
        }

        /// <summary>
        /// 武将牌国别
        /// </summary>
        public enum CharCardCountry
        {
            CHARACTER_CARD_COUNTRY_INVALID = 0,
            CHARACTER_CARD_COUNTRY_WEI = 1,      //魏
            CHARACTER_CARD_COUNTRY_SHU = 2,      //蜀
            CHARACTER_CARD_COUNTRY_WU = 3,      //吴
            CHARACTER_CARD_COUNTRY_QUN = 4,      //群雄
            CHARACTER_CARD_COUNTRY_SHEN = 5,      //神
            CHARACTER_CARD_COUNTRY_PROVOCATEUR = 6,   //野心家势力

            CHARACTER_CARD_COUNTRY_QIN = 100,   //秦
            CHARACTER_CARD_COUNTRY_QI = 101,    //齐
            CHARACTER_CARD_COUNTRY_CHU = 102,   //楚
            CHARACTER_CARD_COUNTRY_YAN = 103,   //燕
            CHARACTER_CARD_COUNTRY_ZHAO = 104,  //赵
            CHARACTER_CARD_COUNTRY_HAN = 105,   //韩
            CHARACTER_CARD_COUNTRY_JIN = 106,   //晋
            CHARACTER_CARD_COUNTRY_HAN1 = 107,  //汉
            CHARACTER_CARD_COUNTRY_XIA = 108,   //夏
            CHARACTER_CARD_COUNTRY_SHANG = 109, //商
            CHARACTER_CARD_COUNTRY_ZHOU = 110,  //周
            CHARACTER_CARD_COUNTRY_LIANG = 111, //凉
            CHARACTER_CARD_END,
        }

        // 武将性别
        public enum HeroGender
        {
            CHARACTER_CARD_INVALID = 0,
            CHARACTER_CARD_MALE = 1,        //男
            CHARACTER_CARD_FEMALE = 2,        //女
        }

        // 技能类型
        public enum SpellType
        {
            SPELL_TYPE_NORMAL = (1 << 0),//基本牌技能
            SPELL_TYPE_STRATAGEM = (1 << 1),//锦囊技能
            SPELL_TYPE_EQUIP = (1 << 2),//装备技能
            SPELL_TYPE_CHARACTER = (1 << 3),//武将技能

            SPELL_TYPE_LOCKED = (1 << 4),//锁定技
            SPELL_TYPE_TRIGGER = (1 << 5),//触发技能
            SPELL_TYPE_LIMIT = (1 << 6),//限定技
            SPELL_TYPE_TEMPOR = (1 << 7),//主公技
            SPELL_TYPE_FU_JIANG_JI = (1 << 8),//副将技
            SPELL_TYPE_ZHU_JIANG_JI = (1 << 9),//主将技
            SPELL_TYPE_ROUSE = (1 << 10),//觉醒技
            SPELL_TYPE_SWITCH = (1 << 12),//转换技

            SPELL_TYPE_ZHEN_FA_DUI_LIE = (1 << 13),//队列阵法
            SPELL_TYPE_ZHEN_FA_WEI_GONG = (1 << 14),//围攻阵法
            SPELL_TYPE_NEGATIVE = (1 << 15),//减益
            SPELL_TYPE_POSITIVE = (1 << 16),//增益
            SPELL_TYPE_BUFF = (1 << 17),//buff
            SPELL_TYPE_SCHEME = (1 << 18),//计谋
            SPELL_TYPE_MODEL = (1 << 19),//模式技能，加在role上，不能被断肠等
            SPELL_TYPE_DUTY = (1 << 20),//使命技
            SPELL_TYPE_DAMAGE = (1 << 21),//伤害类技能
            SPELL_TYPE_HIDE = (1 << 22),//隐藏技能
        };
        public enum SeatState
        {
            /// <summary>
            /// 默认状态，不可进行座位选择
            /// </summary>
            DEFAULT = 0,
            /// <summary>
            /// 不可选
            /// </summary>
            UNABLE = 1,
            /// <summary>
            /// 可选
            /// </summary>
            ENABLE,
            /// <summary>
            /// 被选中
            /// </summary>
            SELECTED,
            /// <summary>
            /// 默认被选中，无法取消
            /// </summary>
            DEFAULT_SELECTED
        }


        public enum CardState
        {
            /// <summary>
            /// 默认状态，所有手牌不可操作
            /// </summary>
            DEFAULT = 0,
            /// <summary>
            /// 不可选
            /// </summary>
            UNABLE,
            /// <summary>
            /// 可选
            /// </summary>
            ENABLE,
            /// <summary>
            /// 被选中
            /// </summary>
            SELECTED,


        }

        public enum BtnState
        {
            /// <summary>
            /// 不可点击
            /// </summary>
            DISABLE = 0,
            /// <summary>
            /// 可点击
            /// </summary>
            NORMAL,
            /// <summary>
            /// 被选中
            /// </summary>
            SELECTED,
            /// <summary>
            /// 被锁定
            /// </summary>
            LOCKED
        };

        /// <summary>
        /// 场上可操作通用按钮类型
        /// </summary>
        public enum EmOptBtnType : int
        {
            /// <summary>
            /// 确定
            /// </summary>
            CONFIRM = 0,
            /// <summary>
            /// 自定义按钮，从1开始
            /// </summary>
            CUSTOM01 = 1,
            CUSTOM02,
            CUSTOM03,
            CUSTOM04,
            CUSTOM05,
            /// <summary>
            /// 取消
            /// </summary>
            CANCEL = 100,
            /// <summary>
            /// 重铸
            /// </summary>
            RECAST,
            /// <summary>
            /// 弃置
            /// </summary>
            DISCARD,
            /// <summary>
            /// /跳过无懈可击
            /// </summary>
            SKIP_WXKJ,
            /// <summary>
            /// 结束出牌阶段
            /// </summary>
            PHASE_END,



        };

        /// <summary>
        /// 可操作卡牌区 卡牌类型
        /// </summary>
        public enum EmOptCardType
        {
            /// <summary>
            /// 手牌，CardId 有效
            /// </summary>
            IN_HAND = 1,
            /// <summary>
            /// 装备区牌，CardId 有效
            /// </summary>
            IN_EQUIP,
            /// <summary>
            /// 场外区牌
            /// </summary>
            IN_REMOVED,
            /// <summary>
            /// 虚拟牌，CardId无效
            /// </summary>
            VIRTUAL,
            /// <summary>
            /// 属于手牌or装备区牌的转化牌，CardId有效
            /// </summary>
            TRAN_CARD,
            /// <summary>
            /// 属于手牌 的转化牌，CardId有效
            /// </summary>
            TRAN_HAND_CARD,
            /// <summary>
            /// 属于场外牌的转化牌
            /// </summary>
            TRAN_REMOVED_CARD,
            /// <summary>
            /// 将手牌都转化为一张牌， CardId无效
            /// </summary>
            TRAN_ALL_HANDCARD,

        };

        public enum IdentityType
        {
            INVALID,
            FIGURE_EMPEROR,         //主公
            FIGURE_MINISTER,        //忠臣
            FIGURE_REBEL,           //反贼
            FIGURE_PROVOCATEUR      //内奸
        };

        public enum TryOptRet
        {
            Invalid = -1,
            OK = 0, //成功，发生变化
            NO, //成功，未发生变化
            FAILED,//失败，一般是检查到行为不合法
            PopStack, //当前Action需要出栈，当前Try由出栈后栈顶Action执行
        };


        public enum EmZoneType
        {
            ZONE_INVALID = 0,
            ZONE_CARDPILE,     //摸牌堆
            ZONE_DISACARPILE,  //弃牌堆
            ZONE_STACK,        //堆叠区域
            ZONE_REMOVED,      //场外
            ZONE_HAND,         //手牌区
            ZONE_EQUIP,        //装备区
            ZONE_JUDGE,        //判定区
            ZONE_SPELL,         //技能使用的牌的区域，属于具体spell
            ZONE_SHUFFLE,       //洗牌区(只是告诉客户端,洗牌了或者牌堆的数量)
            ZONE_TEMP,          //临时区域,如交换时使用,从A区域到temp区域时会触发A失去事件, 从temp到B区域会触发B区域得到卡牌事件(此时卡牌在之前区域的信息不会更新)
            ZONE_DISCARD_BUFF,  //弃牌临时区域 客户端只是用来提示
            ZONE_VIRTUAL,       // 虚拟区，用来存放一些特殊牌，如霹雳车。这个区域不属于任何角色或者技能
            ZONE_LOGIC_EX,      //游戏逻辑额外区域
            ZONE_END,           //结束
        };

        /// <summary>
        /// 废除区域定义
        /// </summary>
        public enum EmZoneAbolish
        {
            ZONE_ABOLISH_NONE = 0,//无效值
            ZONE_ABOLISH_JUDGE = 1,//判定区
            ZONE_ABOLISH_EQUIP = 2,//装备区（这个不会记录的 只是一个占位符）
            ZONE_ABOLISH_EQUIP_WEAPON = 3,//装备区-武器
            ZONE_ABOLISH_EQUIP_ARMOR = 4,//装备区-防具
            ZONE_ABOLISH_EQUIP_HORSE_ATT = 5,//装备区-进攻马
            ZONE_ABOLISH_EQUIP_HORSE_DEF = 6,//装备区-防御马
            ZONE_ABOLISH_EQUIP_TREASURE = 7,//装备区-宝物

            ZONE_ABOLISH_MAX
        };

        /// <summary>
        /// 游戏阶段
        /// </summary>
        public enum EmRolePhase
        {
            PHASE_INIT = 0, //初始化
            PHASE_BEGIN,    //开始
            PHASE_JUDGE,    //判定
            PHASE_DEAL,     //发牌
            PHASE_PLAY,     //出牌
            PHASE_DISCARD,  //弃牌
            PHASE_END,      //结束
            PHASE_CLEARUP,  //清理
            PHASE_TURN_OVER,//全部结束，下一轮
            PHASE_MAX_CNT,

            PHASE_INVALID = 255//无效回合(断线重连后，通知客户端不在自己的回合)
        };

    }
}
