using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network
{
    internal sealed class NetPacket
    {
        public int Id;
        public int Size;
        public byte[] RawData;

        public object UserData;
        public NetPacket Next;

        public NetPacket(int size)
        {
            RawData = new byte[size];
            Size = size;
        }

        public bool Verify()
        {
            return false;
            //byte property = (byte)(RawData[0] & 0x1F);
            //if (property >= PropertiesCount)
            //    return false;
            //int headerSize = HeaderSizes[property];
            //bool fragmented = (RawData[0] & 0x80) != 0;
            //return Size >= headerSize && (!fragmented || Size >= headerSize + NetConstants.FragmentHeaderSize);
        }
    }
}
