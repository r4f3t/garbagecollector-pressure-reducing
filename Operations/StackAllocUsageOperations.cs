using BenchmarkDotNet.Attributes;

namespace SpanUsageExample.Operations;

public class StackAllocUsageOperations
{
    struct VectorStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    
    [Benchmark]
    public void WithNew()
    {
        VectorStruct[] vectors = new VectorStruct[5];
        for (int i = 0; i < 5; i++)
        {
            vectors[i].X = 5;
            vectors[i].Y = 10;
        }
    }
    
    [Benchmark]
    public void WithStackAllocSpan() // When using Span, no need for unsafe context
    {
        Span<VectorStruct> vectors = stackalloc VectorStruct[5];
        for (int i = 0; i < 5; i++)
        {
            vectors[i].X = 5;
            vectors[i].Y = 10;
        }
    }
}