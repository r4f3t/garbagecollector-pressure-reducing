using System.Buffers;
using BenchmarkDotNet.Attributes;

namespace SpanUsageExample.Operations
{
    [MemoryDiagnoser]
    public class ArrayPoolOperations
    {
        public static readonly int Size = 10000;

        [Benchmark]
        public void FillArray()
        {
            var array = new int[Size];
            array[0]++;
        }

        [Benchmark]
        public void FillArrayWithPool()
        {
            var pool = ArrayPool<int>.Shared;
            int[] array = pool.Rent(Size);
            array[0]++;
            pool.Return(array);
        }

    }
}