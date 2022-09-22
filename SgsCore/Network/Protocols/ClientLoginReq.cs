using SgsCore.Network.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotFix.Protocol
{
    public class ClientLoginReq : BaseProtocol
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


        public override void ReadParams()
        {
            ReadUShort();
            LoginType = ReadUShort();
            Username = ReadString(48);
            Password = ReadString(48);
            NumberAccount = ReadString(40);
            LoginFrom = ReadUShort();
            Reserve = ReadUShort();
            Visible = ReadBool();
            flistVer = ReadString(32);
            uuid = ReadString(65);
        }

        public override void WriteParams()
        {
            Write((ushort)270);
            Write(LoginType);
            Write(Username, 48);
            Write(Password, 48);
            Write(NumberAccount, 40);
            Write(LoginFrom);
            Write(Reserve);
            Write(Visible);
            Write(flistVer, 32);
            Write(uuid, 65);
        }
    }
}
