using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network
{
    public sealed class NetworkManager
    {
        private readonly GameTcpClient _gameTcpClient;

        public NetworkManager(string address, int port)
        {
            _gameTcpClient = new GameTcpClient(address, port);
        }
    }
}
