using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.Protocols
{
    public class BaseProtocol : IProtocol, ISocketData
    {
        public enum LOG_LEVEL
        {
            Log = 0,
            Warning,
            Error
        }
        public const string CHARSET = "GB2312";
        public BaseProtocol() { }
        private Type mType;
        virtual public string DataInfo { get { return ""; } }
        virtual public int LogLevel { get { return (int)LOG_LEVEL.Log; } }
        virtual public string Scene { get { return ""; } }
        virtual public ProtocolID GetProtocolID
        {
            get { return 0; }
        }

        public int ID
        {
            get
            {
                if (mType == null)
                {
                    mType = this.GetType();
                }
                int value = 0;
                if (ProtocolDictionary.GetInstance().ProtocolDicName2ID.TryGetValue(mType.ToString(), out value))
                {
                    return value;
                }
                return -1;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                if (mType == null)
                {
                    mType = this.GetType();
                }
                if (name == null)
                {
                    name = mType.ToString();
                    name = name.Substring(name.LastIndexOf(".") + 1);
                }
                return name;
            }
        }


        public byte[] GetBytes()
        {
            data = new byte[0];
            WriteParams();
            mSize = data.Length;

            _backupData = new byte[mSize];
            Array.Copy(data, _backupData, mSize);

            return data;
        }
        protected byte[] Data
        {
            get
            {
                return data;
            }
        }
        private byte[] _backupData;
        public byte[] BackupData
        {
            get
            {
                return _backupData;
            }
        }
        public float DispatchTime; // 协议的相对时间
        public int IsSend; // 是否是发送协议
        private float _recvTime; //协议接收到的相对时间

        public float RecvTime
        {
            set
            {
                _recvTime = value;
            }
            get
            {
                return _recvTime;
            }
        }

        private byte[] data;
        private int position = 0;
        private int mSize = 0;
        private int mClientID = 0;
        public void SetBytes(byte[] bytes, int size, int clientID)
        {
            data = bytes;
            _backupData = new byte[size];
            Array.Copy(bytes, _backupData, size);
            position = 0;
            mSize = size;
            mClientID = clientID;
            ReadParams();
        }
        public int UserID
        {
            get
            {
                return mClientID;
            }
        }
        public virtual void ReadParams()
        {

        }
        public virtual void WriteParams()
        {

        }
        public int BytesAvailable
        {
            get
            {
                return mSize - position;
            }
        }
        public int Size
        {
            get
            {
                return mSize;
            }
        }
        public int Position
        {
            set
            {
                position = value;
            }
            get
            {
                return position;
            }
        }

        public void Write(byte[] value)
        {
            try
            {
                if (value == null || value.Length == 0)
                    return;

                Array.Resize<byte>(ref data, data.Length + value.Length);
                Array.Copy(value, 0, data, data.Length - value.Length, value.Length);
            }
            catch (Exception e)
            {
            }
        }

        public void Write(uint[] value)
        {
            try
            {
                if (value == null || value.Length == 0)
                    return;

                Array.Resize<byte>(ref data, data.Length + value.Length);
                Array.Copy(value, 0, data, data.Length - value.Length, value.Length);
            }
            catch (Exception e)
            {
            }
        }

        public bool ReadBool()
        {
            bool value;
            try
            {
                value = data[position] == 0 ? false : true;
            }
            catch (Exception e)
            {
                value = false;
                --position;
            }
            ++position;
            return value;
        }
        public void Write(bool value)
        {
            try
            {
                Array.Resize<byte>(ref data, data.Length + 1);
                data[data.Length - 1] = value ? (byte)1 : (byte)0;
            }
            catch (Exception e)
            {
            }
        }
        public byte ReadByte()
        {
            byte value;
            try
            {
                value = data[position];
            }
            catch (Exception e)
            {
                value = 0;
                --position;
            }
            ++position;
            return value;
        }



        public void Write(byte value)
        {
            try
            {
                Array.Resize<byte>(ref data, data.Length + 1);
                data[data.Length - 1] = value;
            }
            catch (Exception e)
            {
            }
        }
        public short ReadShort()
        {
            short value;
            try
            {
                value = BitConverter.ToInt16(data, position);
            }
            catch (Exception e)
            {
                value = 0;
                position -= 2;
            }
            position += 2;
            return value;
        }
        public void Write(short value)
        {
            try
            {
                Array.Resize<byte>(ref data, data.Length + 2);
                Array.Copy(BitConverter.GetBytes(value), 0, data, data.Length - 2, 2);
            }
            catch (Exception e)
            {
            }
        }
        public ushort ReadUShort()
        {
            ushort value;
            try
            {
                value = BitConverter.ToUInt16(data, position);
            }
            catch (Exception e)
            {
                value = 0;
                position -= 2;
            }
            position += 2;
            return value;
        }
        public void Write(ushort value)
        {
            try
            {
                Array.Resize<byte>(ref data, data.Length + 2);
                Array.Copy(BitConverter.GetBytes(value), 0, data, data.Length - 2, 2);
            }
            catch (Exception e)
            {
            }
        }
        public int ReadInt()
        {
            int value;
            try
            {
                value = BitConverter.ToInt32(data, position);
            }
            catch (Exception e)
            {
                value = 0;
                position -= 4;
            }
            position += 4;
            return value;
        }

        public UInt64 ReadUInt64()
        {
            UInt64 value;
            try
            {

                value = BitConverter.ToUInt64(data, position);
            }
            catch (Exception e)
            {
                value = 0;
                position -= 8;
            }
            position += 8;
            return value;
        }

        public void Write(int value)
        {
            try
            {
                Array.Resize<byte>(ref data, data.Length + 4);
                Array.Copy(BitConverter.GetBytes(value), 0, data, data.Length - 4, 4);
            }
            catch (Exception e)
            {
            }
        }
        public float ReadFloat()
        {
            float value;
            try
            {
                value = BitConverter.ToSingle(data, position);
            }
            catch (Exception e)
            {
                value = 0;
                position -= 4;
            }
            position += 4;
            return value;
        }
        public void Write(float value)
        {
            try
            {
                Array.Resize<byte>(ref data, data.Length + 4);
                Array.Copy(BitConverter.GetBytes(value), 0, data, data.Length - 4, 4);
            }
            catch (Exception e)
            {
            }
        }
        public uint ReadUInt()
        {
            uint value;
            try
            {
                value = BitConverter.ToUInt32(data, position);
            }
            catch (Exception e)
            {
                value = 0;
                position -= 4;
            }
            position += 4;
            return value;
        }
        public void Write(uint value)
        {
            try
            {
                Array.Resize<byte>(ref data, data.Length + 4);
                Array.Copy(BitConverter.GetBytes(value), 0, data, data.Length - 4, 4);
            }
            catch (Exception e)
            {
            }
        }
        public double ReadDouble()
        {
            double value;
            try
            {
                value = BitConverter.ToDouble(data, position);
            }
            catch (Exception e)
            {
                value = 0;
                position -= 8;
            }
            position += 8;
            return value;
        }
        public void Write(double value)
        {
            try
            {
                Array.Resize<byte>(ref data, data.Length + 8);
                Array.Copy(BitConverter.GetBytes(value), 0, data, data.Length - 8, 8);
            }
            catch (Exception e)
            {
            }
        }
        public string ReadString(int len)
        {
            if (len < 1) return "";
            string value;
            try
            {
                int charCount;
                for (charCount = 0; charCount < len; ++charCount)
                {
                    if (data[position + charCount] == 0x00)
                    {
                        break;
                    }
                }
                value = Encoding.GetEncoding("GB2312").GetString(data, position, charCount);
                byte[] _data = Encoding.Convert(Encoding.GetEncoding("GB2312"), Encoding.UTF8, Encoding.Default.GetBytes(value));
                value = Encoding.Default.GetString(_data);
                //value = Encoding.UTF8.GetString(data, position, charCount); 
            }
            catch (Exception e)
            {
                value = null;
                position -= len;
            }
            position += len;
            return value;
        }
        public int GetStringLenth(string str)
        {
            try
            {
                byte[] strByte;
                if (str.Length > 0)
                {
                    strByte = Encoding.UTF8.GetBytes(str); //Encoding.GetEncoding(936).GetBytes(str);
                }
                else
                {
                    strByte = new byte[0];
                }
                byte bom1 = strByte.Length > 0 ? strByte[0] : (byte)0;
                byte bom2 = strByte.Length > 1 ? strByte[1] : (byte)0;
                byte bom3 = strByte.Length > 2 ? strByte[2] : (byte)0;
                int pos = 0;
                // 忽略 UTF-8 的 BOM 标记 EF BB BF
                if (bom1 == 0xEF && bom2 == 0xBB && bom3 == 0xBF)
                {
                    pos = 3;
                }
                // Big-Endian
                else if (bom1 == 0xFE && bom2 == 0xFF)
                {
                    pos = 2;
                }
                // Little-Endian
                else if (bom1 == 0xFF && bom2 == 0xFE)
                {
                    pos = 2;
                }
                // Android 从输入框中输入的文本，前面会带有这个标记
                else if (bom1 == 0x3F)
                {
                    pos = 1;
                }
                return strByte.Length - pos;
            }
            catch (Exception e)
            {
            }
            return 0;
        }
        public static byte[] GetBytes(string str, int len = 0)
        {
            byte[] strByte;
            if (str.Length > 0)
            {
                strByte = Encoding.UTF8.GetBytes(str); //Encoding.GetEncoding(936).GetBytes(str);
            }
            else
            {
                strByte = new byte[0];
            }

            byte bom1 = strByte.Length > 0 ? strByte[0] : (byte)0;
            byte bom2 = strByte.Length > 1 ? strByte[1] : (byte)0;
            byte bom3 = strByte.Length > 2 ? strByte[2] : (byte)0;
            int pos = 0;
            // 忽略 UTF-8 的 BOM 标记 EF BB BF
            if (bom1 == 0xEF && bom2 == 0xBB && bom3 == 0xBF)
            {
                pos = 3;
            }
            // Big-Endian
            else if (bom1 == 0xFE && bom2 == 0xFF)
            {
                pos = 2;
            }
            // Little-Endian
            else if (bom1 == 0xFF && bom2 == 0xFE)
            {
                pos = 2;
            }
            // Android 从输入框中输入的文本，前面会带有这个标记
            else if (bom1 == 0x3F)
            {
                pos = 1;
            }

            if (len <= 0)
            {
                len = strByte.Length - pos;
            }

            int d = len - (strByte.Length - pos);
            Array.Resize<byte>(ref strByte, strByte.Length + d);
            while (d > 0)
            {
                if (d == 1)
                {
                    strByte[strByte.Length - 1] = 0xCC;
                }
                else
                {
                    strByte[strByte.Length - d] = 0x00;
                }
                --d;
            }

            byte[] result = new byte[len];
            Array.Copy(strByte, pos, result, 0, len);
            return result;
        }
        /// <summary>
        /// 根据长度写入字符串，如果长度为0，表示按字符串最短占用字节数去写
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        public void Write(string str, int len = 0)
        {
            try
            {
                byte[] strByte;
                if (str.Length > 0)
                {
                    strByte = Encoding.UTF8.GetBytes(str); //Encoding.GetEncoding(936).GetBytes(str);
                }
                else
                {
                    strByte = new byte[0];
                }
                byte bom1 = strByte.Length > 0 ? strByte[0] : (byte)0;
                byte bom2 = strByte.Length > 1 ? strByte[1] : (byte)0;
                byte bom3 = strByte.Length > 2 ? strByte[2] : (byte)0;
                int pos = 0;
                // 忽略 UTF-8 的 BOM 标记 EF BB BF
                if (bom1 == 0xEF && bom2 == 0xBB && bom3 == 0xBF)
                {
                    pos = 3;
                }
                // Big-Endian
                else if (bom1 == 0xFE && bom2 == 0xFF)
                {
                    pos = 2;
                }
                // Little-Endian
                else if (bom1 == 0xFF && bom2 == 0xFE)
                {
                    pos = 2;
                }
                // Android 从输入框中输入的文本，前面会带有这个标记
                else if (bom1 == 0x3F)
                {
                    pos = 1;
                }
                if (len <= 0)
                {
                    len = strByte.Length - pos;
                }
                int d = len - (strByte.Length - pos);
                Array.Resize<byte>(ref strByte, strByte.Length + d);
                while (d > 0)
                {
                    if (d == 1)
                    {
                        strByte[strByte.Length - 1] = 0xCC;
                    }
                    else
                    {
                        strByte[strByte.Length - d] = 0x00;
                    }
                    --d;
                }
                Array.Resize<byte>(ref data, data.Length + len);
                Array.Copy(strByte, pos, data, data.Length - len, len);
            }
            catch (Exception e)
            {
            }
        }


        #region
        public static string GetProtocolString(IProtocol msg)
        {
            string info = "[{0}][ID:{1} Size:{2}";
            string name = "";
            string size = "";
            string id = "";
            PropertyInfo[] pis = msg.GetType().GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                if (pi != null)
                {
                    if (pi.Name == "Name")
                    {
                        name = pi.GetValue(msg, null).ToString();
                    }
                    else if (pi.Name == "Size")
                    {
                        size = pi.GetValue(msg, null).ToString();
                    }
                    else if (pi.Name == "ID")
                    {
                        id = pi.GetValue(msg, null).ToString();
                    }
                    else if (pi.Name == "BytesAvailable" || pi.Name == "Position")
                    {

                    }
                    else
                    {
                        info = info + " " + pi.Name + ":" + pi.GetValue(msg, null).ToString();
                    }
                }
            }
            FieldInfo[] ss = msg.GetType().GetFields();
            foreach (FieldInfo s in ss)
            {
                if (s != null)
                {
                    if (s.GetValue(msg) != null)
                    {
                        info = info + " " + s.Name + ":" + s.GetValue(msg).ToString();
                    }
                    else
                    {
                        info = info + " " + s.Name + ":null";
                    }
                }
            }

            string data_str = "    (" + msg.DataInfo + ")";

            info += "]";
            info = string.Format(info, name, id, size) + data_str;
            return info;
        }
        #endregion
    }
}
