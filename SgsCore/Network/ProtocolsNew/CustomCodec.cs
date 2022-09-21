using HotFix.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    public class CustomCodec<TPackageInfo> : IPackageDecoder<IProtocol>
    {
        public IProtocol Decode(ref ReadOnlySpan<byte> buffer, object context)
        {
            throw new NotImplementedException();
        }
    }
}
