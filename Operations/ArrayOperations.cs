using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SpanUsageExample.Operations;

//BenchmarkRunner.Run<ArrayOperations>();

namespace SpanUsageExample.Operations
{
    [MemoryDiagnoser]
    public class ArrayOperations
    {
        public static readonly int[] array = new int[1000000];
        public List<int> list = new List<int>();

        [Benchmark]
        public void FillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] += 10;
            }
        }

        [Benchmark]
        public void FillArrayWitSpan()
        {
            Span<int> span = new Span<int>(array);
            span.Fill(10);
        }

    }
}

