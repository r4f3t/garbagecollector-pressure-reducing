using SpanUsageExample.Operations;

namespace SpanUsageExample;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //var operation = new ArrayOperations();
        //operation.FillArray();
        //operation.FillArrayWitSpan();

        var listOperation = new ListToArrayOperations();
        listOperation.FillList();
        listOperation.IterateList();
        listOperation.IterateListToArray();
        listOperation.IterateListToArrayToSpan();

        Console.ReadLine();
    }
}

