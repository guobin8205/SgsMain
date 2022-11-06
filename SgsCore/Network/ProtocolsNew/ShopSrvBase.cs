using SgsCore.Network.Serializer.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    [Serializable]
    public class ShopSrvBase
    {
        [SgsStringMarker(Size = 48)]
        public string username { get; set; }
        public int return_serverid { get; set; }
        public int reserved { get; set; }
        public int result { get; set; }
    }
}
