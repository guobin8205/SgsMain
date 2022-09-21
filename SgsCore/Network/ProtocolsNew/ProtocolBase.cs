using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ProtocolHeader
    {
        public int id;
        public int size;
        public int userId;
    }

    public abstract class ProtocolBase : IProtocol
    {
        public ProtocolHeader header;

        public virtual bool Decode(ref ReadOnlySpan<byte> buffer)
        {
            throw new NotImplementedException();
        }

        public virtual Span<byte> Encode()
        {
            throw new NotImplementedException();
        }
    }
}
