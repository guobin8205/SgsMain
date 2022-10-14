using Common.Extensions.SpanExt;
using SgsCore.Managers.Record;
using SgsCore.Network.ProtocolsNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network
{
    public class GameTcpClient : TcpClient
    {
        public GameTcpClient(string address, int port) : base(address, port) { }

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }


        protected override void OnConnected()
        {
            Console.WriteLine($"Game TCP client connected a new session with Id {Id}");
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"Game TCP client disconnected a session with Id {Id}");

            // Wait for a while...
            Thread.Sleep(1000);

            // Try to connect again
            if (!_stop)
                ConnectAsync();
        }

        protected override void OnReceived(ReadOnlySpan<byte> buffer, long offset, long size)
        {
            ProtocolHeader ph = buffer.MoveReadStruct<ProtocolHeader>();
            Console.WriteLine($"id={ph.id},size={ph.size},userId={ph.userId}");
            Console.WriteLine(Encoding.UTF8.GetString(buffer.ToArray(), (int)offset, (int)size));
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Game TCP client caught an error with code {error}");
        }

        private bool _stop;
    }
}
