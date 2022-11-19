using BenchmarkDotNet.Attributes;
using SgsConsoleApp.Tests;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsConsoleApp.Benchmarks
{

    [MemoryDiagnoser]
    [HtmlExporter]
    public class BenchTestStructVsClass
    {
        [Params(5, 10, 100, 1000, 10000, 100000, 1000000)]
        public int Count { get; set; }

        private List<SomeStruct> someStructs;
        private List<SomeClass> someClass;

        [GlobalSetup]
        public void Setup()
        {
            someStructs = new List<SomeStruct>();
            someClass = new List<SomeClass>();
        }


        [Benchmark]
        public void GeneratorClass()
        {
            var dt = new DataGenerator();
            dt.GenerateClass(Count);
        }

        [Benchmark]
        public void GeneratorStruct()
        {
            var dt = new DataGenerator();
            dt.GenerateStruct(Count);
        }
    }
}
