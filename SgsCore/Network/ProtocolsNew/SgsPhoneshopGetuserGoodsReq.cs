using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    [Serializable]
    public class SgsPhoneshopGetuserGoodsReq : ShopSrvBase
    {
        public int type { get; set; }
        public int goodsbaseid { get; set; }
    }
}
