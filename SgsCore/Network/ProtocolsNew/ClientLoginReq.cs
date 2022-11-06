using Common.Extensions.SpanExt;
using SgsCore.Network.Serializer.Attributes;
using System;

namespace SgsCore.Network.ProtocolsNew
{
    [Serializable]
    public class ClientLoginReq : ProtocolBase
    {
        public ushort Version { get; set; }
        public ushort LoginType { get; set; }
        [SgsStringMarker(Size =48)]
        public string Username { get; set; }
        [SgsStringMarker(Size = 48)]
        public string Password { get; set; }
    [SgsStringMarker(Size = 40)]
        public string NumberAccount { get; set; }
        public ushort LoginFrom { get; set; } // 1015 通行证账号 1020 第三方账号
        public ushort Reserve { get; set; }
        public bool Visible { get; set; }        //是否显示登录
        [SgsStringMarker(Size = 32)]
        public string flistVer { get; set; }
        [SgsStringMarker(Size = 65)]
        public string uuid { get; set; }


        public override void Encode(Span<byte> buffer)
        {
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
        }

        public override bool Decode(ReadOnlySpan<byte> buffer)
        {
            Version = buffer.MoveReadUShort();
            LoginType = buffer.MoveReadUShort();
            Username = buffer.MoveReadFixedStringGBK(48);
            Password = buffer.MoveReadFixedStringGBK(48);
            NumberAccount = buffer.MoveReadFixedStringGBK(40);
            LoginFrom = buffer.MoveReadUShort();
            Reserve = buffer.MoveReadUShort();
            Visible = buffer.MoveReadBool();
            flistVer = buffer.MoveReadFixedStringGBK(32);
            uuid = buffer.MoveReadFixedStringGBK(65);

            return true;
        }
    }
}
