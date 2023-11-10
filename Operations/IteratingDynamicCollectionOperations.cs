using BenchmarkDotNet.Attributes;

namespace SpanUsageExample.Operations
{
    [MemoryDiagnoser]public class IteratingDynamicCollectionOperations
    {
        public static readonly int Size = 1000000;

        [Benchmark]
        public void IterateList()
        {
            var list = new List<int>();
            for (int i = 0; i < Size; i++)
            {
                list.Add(i);
            }
        }
        
        [Benchmark]
        public void IterateListWithInitializedSize()
        {
            var list = new List<int>(Size);
            for (int i = 0; i < Size; i++)
            {
                list.Add(i);
            }
        }
        
        [Benchmark]
        public void IterateDictionary()
        {
            var dictionary = new Dictionary<int,int>();
            for (int i = 0; i < Size; i++)
            {
                dictionary[i] = i+1;
            }
        }
        
        [Benchmark]
        public void IterateDictionaryWithInitializedSize()
        {
            var dictionary = new Dictionary<int,int>(Size);
            for (int i = 0; i < Size; i++)
            {
                dictionary[i] = i+1;
            }
        }
    }
}