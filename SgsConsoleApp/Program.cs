// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using BenchmarkDotNet.Running;
using Common.Extensions.SpanExt;
using SgsConsoleApp.Benchmarks;
using SgsCore.Managers;

Console.WriteLine("Hello, World!");

//var summary = BenchmarkRunner.Run<BenchTest>();


ReadOnlyMemory<byte> buff = await RecordMgr.LoadFileAsync(@"demo.bin");
RecordMgr.ReadRecord(buff.Span);

RecordMgr.Write();
//Span<byte> bufferSpan = buff.AsSpan<byte>();