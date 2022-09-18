using System;
using BenchmarkDotNet.Attributes;
using SgsCore.Managers;

namespace SgsConsoleApp.Benchmarks
{
    public class BenchTest
    {
        [Benchmark]
        public async Task TestAsync()
        {
            var buff = await RecordMgr.LoadFileAsync(@"demo.bin");
            Console.WriteLine(buff.Length);
        }
    }
}

