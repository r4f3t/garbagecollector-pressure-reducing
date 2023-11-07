using System;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SpanUsageExample.Operations;

BenchmarkRunner.Run<ListToArrayOperations>();

namespace SpanUsageExample.Operations
{
    [MemoryDiagnoser]
    public class ListToArrayOperations
    {
        public List<int> list = new List<int>();

        [Benchmark]
        public void FillList()
        {
            for (int i = 0; i < 10000; i++)
            {
               list.Add(i);
            }
        }
        
        [Benchmark]
        public void IterateList()
        {
            var sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
        }

        [Benchmark]
        public void IterateListToArray()
        {
            var sum = 0;
            var array = list.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
        }
        
        [Benchmark]
        public void IterateListToArrayToSpan()
        {
            var sum = 0;
            var span = CollectionsMarshal.AsSpan(list);
            foreach (int num in span)
            {
                sum += num;
            }
        }
    }
}

