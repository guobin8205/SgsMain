using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{
    class MsgUpdateRoleDataExNtf:BaseProtocol
    {
        public enum OptDataId
        {
            OPT_DATA_INVALID = 0,
            OPT_DATA_ADD_EX_SPELL,          //给role添加技能 data为spell id(袁术-伪帝)
            OPT_DATA_DEL_EX_SPELL,          //给role删除技能 data为spell id(断肠)
            OPT_DATA_IS_FIGURE_TAP,         //身份牌是否横置(public)
            OPT_DATA_IS_CHARCARD_TAP,       //武将牌是否横置(public)
            OPT_DATA_IS_CHARCARD_TURN_OVER, //武将牌是否翻面(public)
            OPT_DATA_REST,                  //重整(public)
            OPT_DATA_LIMITED,               //限定技使用
            OPT_DATA_ADD_SPELL_EFFECT,      //增加技能效果
            OPT_DATA_REMOVE_SPELL_EFFECT,   //删除技能效果
            OPT_DATA_SET_CHARACTER_SPELL,   //设置武将有哪些技能
            OPT_ADD_HUA_SHEN_CARD,          //增加化身牌
            OPT_SET_HUA_SHEN_CARD,          //设置化身牌
            OPT_SET_CHARACTER_COUNTRY,      //设置武将国家
            OPT_SET_CHARACTER_GENDER,       //设置武将性别
            OPT_DATA_ADD_CHARACTER_SPELL_NEW, //给role添加技能 data[0]表示武将ID，为无效值时表示添加到角色，data[1]:添加的技能个数
            OPT_DATA_DEL_CHARACTER_SPELL_NEW, //给role删除技能 data[0]表示武将ID，为无效值时表示从角色身上删除; data[1]:删除的技能个数
            OPT_DATA_SET_CHARACTER_SPELL_NEW, //设置武将技能 data[0]表示武将ID，为无效值时表示设置的是玩家的技能;data[1]:技能个数
            OPT_DATA_SET_COMMON_HUAN_SHEN_CARD,//这一局中常用化身牌
            OPT_DATA_XIAO_BING, //小兵状态
            OPT_DATA_STAR_PRIVILEGE,
            OPT_DATA_FU_LIN,    // 腹鳞牌
            OPT_DATA_DON_NOT_DISCARD_IN_DISCARD_PHASE,
            OPT_DATA_ROLE_COUNTRY_NTF,      //角色国籍，在分将之前
            OPT_DATA_LIMITED_RESET,         //限定技重置
            OPT_DATA_CANCEL_XIAO_BING,      //取消小兵
            OPT_DATA_MAX,                   //ID的上限
        };
        enum emModifyType
        {
            modify_type_set = 0,
            modify_data_inc,
            modify_type_dec,
        };

        public byte seatId;
        public bool isSpell;    // id是否spellid还是操作id
        public ushort id;
        public byte dataCnt;
        public List<int> datas;

        public override void ReadParams()
        {
            seatId = ReadByte();
            isSpell = ReadBool();
            id = ReadUShort();
            dataCnt = ReadByte();
            datas = new List<int>();
            for (int i = 0; i < dataCnt; ++i)
            {
                if (BytesAvailable < 4)
                    break;
                datas.Add(ReadInt());
            }


        }
    }
}
