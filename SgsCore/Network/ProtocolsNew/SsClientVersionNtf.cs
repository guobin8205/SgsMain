using Common.Extensions.SpanExt;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    internal class SsClientVersionNtf : ProtocolBase
    {
        private uint version;
        private uint version_limit;
        private bool enable_pb;
        public override Span<byte> Encode()
        {
            return null;
        }

        public override bool Decode(ref ReadOnlySpan<byte> buffer)
        {
            version = buffer.MoveReadUInt();
            version_limit = buffer.MoveReadUInt();
            enable_pb = buffer.MoveReadBool();
            return true;
        }

        public override string ToString()
        {
            return $"version={version},version_limit={version_limit},enable_pb={enable_pb}";
        }

    }
}
