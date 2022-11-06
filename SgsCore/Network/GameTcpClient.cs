using Common.Extensions.SpanExt;
using SgsCore.Managers.Record;
using SgsCore.Network.Processors;
using SgsCore.Network.ProtocolsNew;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SgsCore.Network
{
    public class GameTcpClient : TcpClient
    {
        private AesEncryptProcessor _encryptProcessor = null;
        private const int HEADER_DATA_LENGTH = 12;

        public GameTcpClient(string address, int port) : base(address, port) 
        {
            this.OnHandleReceivedData = this.HandleReceivedData;
            //this._encryptProcessor = new AesEncryptProcessor();
        }

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

            Thread.Sleep(1000);

            if (!_stop)
                ConnectAsync();
        }

        private bool HandleReceivedData(Buffer receiveBuffer, int size)
        {
            ProtocolHeader? header = null;
            if (!TryGetHeader(receiveBuffer, out header) || !header.HasValue)
            {
                return false;
            }
            int offset = HEADER_DATA_LENGTH;
            int datalen = header.Value.size - HEADER_DATA_LENGTH;
            this._encryptProcessor?.ProcessInboundPacket(receiveBuffer, offset, datalen);

            Console.WriteLine($"id={header.Value.id},size={header.Value.size},userId={header.Value.userId}");
            Console.WriteLine(Encoding.UTF8.GetString(receiveBuffer.Data, offset, datalen));

            var buffer = receiveBuffer.AsReadOnlySpan(HEADER_DATA_LENGTH, datalen);
            SsClientVersionNtf ssClientVersionNtf = new SsClientVersionNtf();
            ssClientVersionNtf.Decode(buffer);

            receiveBuffer.RemoveAndAdjust(0, header.Value.size);

            this.HandleReceivedData(receiveBuffer, size);
            return false;
        }

        private bool TryGetHeader(Buffer receiveBuffer, out ProtocolHeader? header)
        {
            header = null;
            if (receiveBuffer.Size >= HEADER_DATA_LENGTH)
            {
                var buffer = receiveBuffer.AsSpan();
                ProtocolHeader? ph = buffer.ReadStruct<ProtocolHeader>();
                if (ph.HasValue)
                {
                    header = ph;
                    return true;
                }
            }
            return false;
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Game TCP client caught an error with code {error}");
        }

        private bool _stop;
    }
}
