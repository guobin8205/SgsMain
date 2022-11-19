using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsConsoleApp.Tests
{
    internal class DataGenerator
    {
        public List<SomeClass> GenerateClass(int count)
        {
            var items = new List<SomeClass>(count);

            for (var i = 0; i < count; i++)
            {
                items.Add(new SomeClass
                {
                    Value1 = i,
                    Value2 = i,
                    Value3 = i,
                    Value4 = i,
                });
            }

            return items;
        }

        public List<SomeStruct> GenerateStruct(int count)
        {
            var items = new List<SomeStruct>(count);

            for (var i = 0; i < count; i++)
            {
                items.Add(new SomeStruct
                {
                    Value1 = i,
                    Value2 = i,
                    Value3 = i,
                    Value4 = i,
                });
            }

            return items;
        }
    }
}
