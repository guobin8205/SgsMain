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
        void Encode(Span<byte> buffer);

        bool Decode(ReadOnlySpan<byte> buffer);
    }
}
