using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.Protocols
{
    public interface IProtocol
    {
        string Scene { get; }
        int ID { get; }
        byte[] GetBytes();
        void SetBytes(byte[] bytes, int size, int clientID);
        string Name { get; }

        int Size { get; }
        int UserID { get; }

        string DataInfo { get; }
        int LogLevel { get; }

        float RecvTime { set; get; }

        // TODO : should add a uuid to each protocol data, to check if the net transmission is success

    }
    public interface ISocketData
    {
        //void Write(byte[] value);
        bool ReadBool();
        void Write(bool value);
        byte ReadByte();
        void Write(byte value);
        short ReadShort();
        void Write(short value);
        ushort ReadUShort();
        void Write(ushort value);
        int ReadInt();
        void Write(int value);
        float ReadFloat();
        void Write(float value);
        uint ReadUInt();
        void Write(uint value);
        double ReadDouble();
        void Write(double value);
        string ReadString(int len);
        void Write(string str, int len);
        int BytesAvailable { get; }
        int Size { get; }
        int Position { get; set; }
    }

    public interface IEasySocket
    {
        double TimeOut { get; set; }
        bool Connected { get; }
        void Init();
        bool Connect(string host, int port);
        void Close();

        void BeginSend(byte[] buffer);

        void BeginReceive(byte[] buffer);
    }
}
