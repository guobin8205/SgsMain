using Common.Extensions.SpanExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    public class ClientLoginReq : ProtocolBase
    {
        public ushort LoginType = 2;
        public string Username = "";
        public string Password = "";
        public string NumberAccount = "";
        public ushort LoginFrom = 1015; // 1015 通行证账号 1020 第三方账号
        public ushort Reserve = 0;
        public bool Visible = true;        //是否显示登录
        public string flistVer = "4.0.8|110110|6";
        public string uuid = "UUID";

        public override Span<byte> Encode()
        {
            byte[] buf = new byte[300];
            Span<byte> buffer = new Span<byte>(buf);
            buffer.MoveWrite((ushort)270);
            buffer.MoveWrite(LoginType);
            buffer.MoveWrite(Username, 48);
            buffer.MoveWrite(Password, 48);
            buffer.MoveWrite(NumberAccount, 40);
            buffer.MoveWrite(LoginFrom);
            buffer.MoveWrite(Reserve);
            buffer.MoveWrite(Visible);
            buffer.MoveWrite(flistVer, 32);
            buffer.MoveWrite(uuid, 65);

            //Span<byte> ret = new Span<byte>(buf, 0, buf.Length - buffer.Length);
            return null;
        }
    }
}
