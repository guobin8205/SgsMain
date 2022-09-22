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
using SgsCore.Network.Protocols;

//Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

Console.WriteLine("Hello, World!");

var login2 = new SgsCore.Network.ProtocolsNew.ClientLoginReq();
login2.Encode();

var summary = BenchmarkRunner.Run<BenchCodec>();

//ReadOnlyMemory<byte> buff = await RecordMgr.LoadFileAsync(@"demo.bin");
//RecordMgr.ReadRecord(buff.Span);

//RecordMgr.Write();
//Span<byte> bufferSpan = buff.AsSpan<byte>();
