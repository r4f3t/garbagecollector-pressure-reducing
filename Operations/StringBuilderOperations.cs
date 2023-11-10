using System.Text;
using BenchmarkDotNet.Attributes;

namespace SpanUsageExample.Operations;

public class StringBuilderOperations
{
    public int Iterations = 1000;

    [Benchmark]
    public void RegularConcatenation()
    {
        string result = "";
        for (int i = 0; i < Iterations; i++)
        {
            result += "abc";
        }
    }

    [Benchmark]
    public void StringBuilderConcatenation()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Iterations; i++)
        {
            sb.Append("abc");
        }
        string result = sb.ToString();
    }
}