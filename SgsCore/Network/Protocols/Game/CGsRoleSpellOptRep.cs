using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotFix.Protocol
{ 
    class CGsRoleSpellOptRep : BaseProtocol
    {

        enum EmOpt
        {
            OPT_INVALID = 0,
            OPT_SEL_COLOR,      //选择花色  dataCnt为1，data[0]为花色
            OPT_QUESTION,       //质疑      dataCnt为1，data[0]等于1时为质疑，为0时表示不质疑
            OPT_HUJIA,          //护驾
            OPT_GUHUO_RESULT,   //蛊惑结果(S->C)
            OPT_JIJIANG_RESULT, //激将结果(S->C)
            OPT_GUANXING_RESULT,    //观星/心战结果(S->C)
            OPT_JUDGE_RESULT,   //判定结果(S->C)
            OPT_ERR,            //操作错误
            OPT_PINDIAN_RESULT, //拼点结果
            OPT_JUDGE_CARD,     //(第一手)判定牌
            OPT_PINDIAN_CARD,   //已出拼点牌
            OPT_GUANXING_MOVECARD,  // 观星卡牌移动
            OPT_SHOW,           // 展示
            OPP_XINZHAN_RESULT,
            OPP_SPELL_EFFECT,   //技能效果生效
            OPP_SEL_TARGET_RESULT,//选择目标结果
            OPT_REFUSED_PIN_DIAN, //拒绝拼点
            OPT_WAIT_NEXT_WU_XIE,   //等待下个无懈可击触发
            OPT_FACE_UP_CHARACTER,  //亮将
            OPT_SHOW_CHARACTER,     //展示武将
            OPT_CANCEL_TRIGGER,     //不使用触发的技能
            OPT_SPELL_SEL,//技能操作的选择
            OPT_GETCARD_RESULT,     // 从XXX得到牌，可能是0张
            OPT_DOUDIZHU_ASK_MULTIPLE,      // 斗地主-询问叫倍数
            OPT_DOUDIZHU_CHOOSE_HP_CARD,    // 斗地主-农民死后询问另一农民回血或摸牌
            OPT_SPELL_OVER,
            OPT_SPELL_CANCEL_EFFECT,    //锦囊被取消效果（无懈）
            OPT_WIPE_RESULT,
            OPT_AI_ERROR = 29,          //AI响应错误 data[0]错误的协议号 data[1] 错误代码 
            OPT_SEL_NUM = 31,           //选择点数
                                        //OPT_GUESS_RESULT = 32,		//猜测结果
            OPT_MILITARYORDER_RESULT = 33,  //军令执行结果(S->C)
            OPT_SHOW_CHARACTER_NEW = 34,
            OPT_ENTER_FIERCE_BATTLE = 100, // 进入鏖战模式
            OPT_ENTER_PECULIAR_DAMAGE,     // 进入特殊掉血	
            OPT_VIRTUAL_CARD_OVER,
            OPT_PRESENT_CARD,
            OPT_USE_CARD_FAIL,
        }

        public byte seatId = 0; //执行回复的seatid
        public byte optType = 0; //回复的操技能id作类型 由EmOpt定义
        public ushort spellId = 0; //引发的技能id
        public byte dataCnt = 0; //回复的数据个数
        public List<uint> datas; //回复的数据 根据类型不同不同

        public override void WriteParams()
        {
            Write(seatId);
            Write(optType);
            Write(spellId);
            Write(dataCnt);
            Write(datas.ToArray());
        }

        protected override void ReadParams()
        {
            seatId = ReadByte();
            optType = ReadByte();
            spellId = ReadUShort();
            dataCnt = ReadByte();
            datas = new List<uint>();
            for (int i = 0; i < dataCnt; ++i)
            {
                if ( BytesAvailable < 4)
                    break;
                datas.Add(ReadUInt());
            }
           
        }
    }

}
