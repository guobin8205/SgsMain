using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    public interface IPackageEncoder<in TPackageInfo>
    {
        int Encode(Span<byte> buffer, TPackageInfo pack);
    }
}
