using Common.Extensions.SpanExt;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

        public byte[] data;

        public override Span<byte> Encode()
        {
            Span<byte> buffer = stackalloc byte[1024];
            Span<byte> writer = buffer;
            writer.MoveWrite((ushort)270);
            writer.MoveWrite(LoginType);
            writer.MoveWrite(Username, 48);
            writer.MoveWrite(Password, 48);
            writer.MoveWrite(NumberAccount, 40);
            writer.MoveWrite(LoginFrom);
            writer.MoveWrite(Reserve);
            writer.MoveWrite(Visible);
            writer.MoveWrite(flistVer, 32);
            writer.MoveWrite(uuid, 65);
            buffer.Slice(0, writer.Length);

            int datalen = buffer.Length - writer.Length;
            byte[] bytes = new byte[datalen];
            Span<byte> ret = new Span<byte>(bytes);
            buffer.Slice(0, datalen).CopyTo(ret);
            return ret;

            //return null;
        }

        public override bool Decode(ref ReadOnlySpan<byte> buffer)
        {
            buffer.MoveReadUShort();
            LoginType = buffer.MoveReadUShort();
            Username = buffer.MoveReadFixedString(48);
            Password = buffer.MoveReadFixedString(48);
            NumberAccount = buffer.MoveReadFixedString(40);
            LoginFrom = buffer.MoveReadUShort();
            Reserve = buffer.MoveReadUShort();
            Visible = buffer.MoveReadBool();
            flistVer = buffer.MoveReadFixedString(32);
            uuid = buffer.MoveReadFixedString(65);

            return true;
        }
    }
}
