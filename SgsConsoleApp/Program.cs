// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using SgsConsoleApp.Benchmarks;
using SgsCore.Network;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;
using Effortless.Net.Encryption;
using SgsCore.Network.Crypto;
using SgsCore.Network.Processors;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MessagePipe;
using SgsCore.Network.Serializer;
using SgsCore.Network.ProtocolsNew;
using BenchmarkDotNet.Loggers;
using System.Net.Sockets;
using System.Reflection.Metadata;
using Common.Extensions.SpanExt;
using Common.Helpers;
using Newtonsoft.Json;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {


        //var summary = BenchmarkRunner.Run<BenchmarkAes>();
        //return;

        //GC.Collect();
        //GC.WaitForPendingFinalizers();
        //GC.Collect();
        //GC.TryStartNoGCRegion(1000 * 1000 * 100, true);
        //var login2 = new SgsCore.Network.ProtocolsNew.ClientLoginReq();
        //login2.LoginType = 2;
        //login2.LoginFrom = 1015;
        //login2.NumberAccount = "aaaaaaa";
        //login2.Username = "guobin82062013";
        //login2.Password = "asdfsdfsdfs";
        //login2.flistVer = "4.0.8|110110|6";
        //login2.uuid = "UUID";
        //Span<byte> buffer = stackalloc byte[1024];
        //login2.Encode(buffer);
        //login2.Decode(buffer);

        //0F62000050000000000000006B696E676C7130303100000000000000000000000000000000000000000000000000000000000000000000000000000000000000E3AD1200000000001300000000000000

        var serializer = new NetSerializer();
        SgsPhoneshopGetuserGoodsReq req = new SgsPhoneshopGetuserGoodsReq();
        req.username = "kinglq001";
        req.reserved = 1224163;
        req.return_serverid = 0;
        req.type = 19;
        req.goodsbaseid = 0;
        var bytes = serializer.Serialize<SgsPhoneshopGetuserGoodsReq>(req);

        int nlen = bytes.Length + 12;
        var buffer = new byte[nlen];
        Span<byte> bufferSpan = new Span<byte>(buffer);
        bufferSpan.MoveWrite((int)25103);
        bufferSpan.MoveWrite((int)nlen);
        bufferSpan.Move(4);
        bufferSpan.MoveWrite(bytes);


        string hexstring = "1E6200007D00000000000000707966323030000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001B756600000000003339303130323230323231313032313934393531333536303830353237380000F40100000145A106000100000000000000E1FD1C00";
        byte[] senddata = ByteHexHelper.HexToByte(hexstring);
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(req));
        //Console.WriteLine(ByteHexHelper.ByteToHex(buffer));
        //var loginReq = new SgsCore.Network.ProtocolsNew.ClientLoginReq();
        //loginReq.Username = "gb01";
        //loginReq.flistVer = "12431431";
        //byte[] buffer = serializer.Serialize<ClientLoginReq>(loginReq);
        //var reader = new NetDataReader(buffer);
        //var obj = serializer.Deserialize<ClientLoginReq>(reader);

        //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        //var login2 = new SgsCore.Network.ProtocolsNew.ClientLoginReq();
        //login2.Encode();

        //var summary = BenchmarkRunner.Run<BenchCodec>();
        //return;

        //ReadOnlyMemory<byte> buff = RecordMgr.LoadFileAsync(@"demo.bin").GetAwaiter().GetResult();
        //RecordMgr.ReadRecord(buff.Span);

        //ReadOnlySpan<byte> bufferSpan = buff.Span;

        string address = "10.225.21.175";
        int port = 41000;

        address = "10.225.254.156";
        port = 46001;
        var client = new GameTcpClient(address, port);
        Console.Write("Client connecting...");
        client.ConnectAsync();
        Console.WriteLine("Done!");



        Console.WriteLine("Press Enter to stop the client or '!' to reconnect the client...");
        for (; ; )
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line))
                break;

            // Disconnect the client
            if (line == "!")
            {
                Console.Write("Client disconnecting...");
                client.DisconnectAsync();
                Console.WriteLine("Done!");
                continue;
            }

            // Send the entered text to the chat server
            client.SendAsync(senddata);
        }
    }
}