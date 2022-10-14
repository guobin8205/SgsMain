using System;
using BenchmarkDotNet.Attributes;
using SgsCore.Managers;

namespace SgsConsoleApp.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchTest
    {
        [Params(10, 100)]
        public int N;

        [Benchmark]
        public void TestAsync()
        {
            for (int i = 0; i < N; i++)
            {
                ReadOnlyMemory<byte> buff = RecordMgr.LoadFileAsync(@"demo.bin").GetAwaiter().GetResult();
                Console.WriteLine(buff.Length);
            }
        }
    }
}

