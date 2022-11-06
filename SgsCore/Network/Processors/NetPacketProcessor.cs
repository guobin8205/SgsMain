using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePipe;

namespace SgsCore.Network.Processors
{
    internal class NetPacketProcessor
    {
        readonly IPublisher<NetPacket> publisher;
    }
}
