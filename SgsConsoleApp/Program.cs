// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using Common.DI;
using Common.Extensions.SpanExt;
using HotFix.Protocol;
using LightInject;
using SgsConsoleApp.Benchmarks;
using SgsCore.Managers;
using SgsCore.Network;
using SgsCore.Network.Protocols;

//Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

//var login2 = new SgsCore.Network.ProtocolsNew.ClientLoginReq();
//login2.Encode();

//var summary = BenchmarkRunner.Run<BenchTest>();

//ReadOnlyMemory<byte> buff = RecordMgr.LoadFileAsync(@"demo.bin").GetAwaiter().GetResult();
//RecordMgr.ReadRecord(buff.Span);

//ReadOnlySpan<byte> bufferSpan = buff.Span;
string address = "10.225.21.175";
int port = 41000;
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
    client.SendAsync(line);
}

