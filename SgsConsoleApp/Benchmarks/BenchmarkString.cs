using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsConsoleApp.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkString
    {
        [Params(100, 200)]
        public int N;

        string countries = null;
        int index, numberOfCharactersToExtract;

        [GlobalSetup]
        public void GlobalSetup()
        {
            countries = "India, USA, UK, Australia, Netherlands, Belgium";
            index = countries.LastIndexOf(",", StringComparison.Ordinal);
            numberOfCharactersToExtract = countries.Length - index;
        }


        [Benchmark]
        public void Substring()
        {
            for (int i = 0; i < N; i++)
            {
                var data = countries.Substring(index + 1, numberOfCharactersToExtract - 1);
            }
        }

        [Benchmark(Baseline = true)]
        public void Span()
        {
            for (int i = 0; i < N; i++)
            {
                var data = countries.AsSpan().Slice(index + 1, numberOfCharactersToExtract - 1);
            }
        }
        [Benchmark]
        public void Momory()
        {
            for (int i = 0; i < N; i++)
            {
                var data = countries.AsMemory().Slice(index + 1, numberOfCharactersToExtract - 1);
            }
        }

    }
}