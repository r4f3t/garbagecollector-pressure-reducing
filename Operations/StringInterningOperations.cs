using BenchmarkDotNet.Attributes;

namespace SpanUsageExample.Operations;

public class StringInterningOperations
{
    public int Size = 1000;
    private string s1 = "Hello";
    private string s2 = " World";
    
    [Benchmark]
    public void WithoutInterning()
    {
        string s1 = GetString();
        string s2 = GetString();
        for (int i = 0; i < Size; i++)
        {
            bool x = s1.Equals(s2);
        }
    }
    
    [Benchmark]
    public void WithInterning()
    {
        string s1 = string.Intern(GetString());
        string s2 = string.Intern(GetString());
        for (int i = 0; i < Size; i++)
        {
            bool x = s1.Equals(s2);
        }
    }
    
    private string GetString()
    {
        return s1 + s2;
    }
}