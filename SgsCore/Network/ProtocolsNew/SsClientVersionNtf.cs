using Common.Extensions.SpanExt;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.ProtocolsNew
{
    [Serializable]
    public class SsClientVersionNtf : ProtocolBase
    {
        #region 协议编码顺序
        public uint version { get; set; }
        public uint version_limit { get; set; }
        public bool enable_pb { get; set; }
        #endregion

        public override void Encode(Span<byte> buffer)
        {
        }

        public override bool Decode(ReadOnlySpan<byte> buffer)
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
