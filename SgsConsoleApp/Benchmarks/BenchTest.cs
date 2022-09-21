using System;
using BenchmarkDotNet.Attributes;
using SgsCore.Managers;

namespace SgsConsoleApp.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchTest
    {
        [Benchmark]
        public void TestAsync()
        {
            RecordMgr.Write();
        }
    }
}

