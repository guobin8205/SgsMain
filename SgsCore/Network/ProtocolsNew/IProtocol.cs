using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    public interface IProtocol
    {
        Span<byte> Encode();
        bool Decode(ref ReadOnlySpan<byte> buffer);
    }
}
